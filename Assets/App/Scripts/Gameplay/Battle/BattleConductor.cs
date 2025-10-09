using System;
using App.Scripts.Infrastructure.VFX;
using Scenes.App.Scripts.Gameplay.UnitRegistryImpl;
using Scenes.App.Scripts.Gameplay.Units;
using UnityEngine;
using Zenject;

namespace Scenes.App.Scripts.Gameplay.Battle
{
  public class BattleConductor : IBattleConductor
  {
    private const float TurnTickDuration = 2f;

    private readonly IUnitRegistry _unitRegistry;
    private readonly IDamageCalculator _damageCalculator;
    private readonly IVFxFactory _vfxFactory;

    private bool _started;
    private bool _ended;
    private float _untilNextTurnTick;
    private UnitGroup _lastAttacked;
    
    public bool IsBattleStarted => _started;
    public bool IsBattleEnded => _ended;
    public bool IsBattleWin { get; private set; } = false;
    public bool IsGameEnded { get; private set; } = false;

    public BattleConductor(IUnitRegistry unitRegistry, IDamageCalculator damageCalculator, IVFxFactory vfxFactory)
    {
      _unitRegistry = unitRegistry;
      _damageCalculator = damageCalculator;
      _vfxFactory = vfxFactory;
    }
    
    public void Tick()
    {
      if (!_started)
        return;

      UpdateTurnTimer();
    }

    public void Start() => _started = true;
    public void Finish() => _ended = true;

    public void Reset()
    {
      _started = false;
      _ended = false;
      _untilNextTurnTick = TurnTickDuration;
      _lastAttacked = UnitGroup.None;
    }

    private void UpdateTurnTimer()
    {
      _untilNextTurnTick -= Time.deltaTime;
      if (_untilNextTurnTick <= 0)
      {
        TurnTick();
        _untilNextTurnTick = TurnTickDuration;
      }
    }

    private void TurnTick()
    {
      if(_lastAttacked == UnitGroup.None)
        ChooseFirstAttacker();

      if (_lastAttacked == UnitGroup.Player)
      {
        _lastAttacked = UnitGroup.Enemy;
        ProcessAttack(attacker: _unitRegistry.Enemy, defender: _unitRegistry.Player);
      }
      else if (_lastAttacked == UnitGroup.Enemy)
      {
        _lastAttacked = UnitGroup.Player;
        ProcessAttack(attacker: _unitRegistry.Player, defender: _unitRegistry.Enemy);
      }

      if (BattleOver())
      {
        Finish();
        IsBattleWin = BattleWon();
      }
    }
    
    private void ChooseFirstAttacker()
    {
      _lastAttacked = UnitGroup.Enemy;
    }

    private void ProcessAttack(IUnit attacker, IUnit defender)
    {
      if (_damageCalculator.HitProbabilityOccurs(attacker, defender))
      { 
        int damage = _damageCalculator.CalculateDamage(attacker, defender);
        attacker.Attack(defender, damage);
      }
      else
        attacker.MissAttack(defender);
    }
    
    public bool BattleOver() => BattleLoosed() || BattleWon();
    private bool BattleLoosed() => _unitRegistry.Player.Health.IsDead;
    private bool BattleWon() => _unitRegistry.Enemy.Health.IsDead;
  }
}