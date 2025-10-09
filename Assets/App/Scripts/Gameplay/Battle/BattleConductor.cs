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
    private const float TurnTickDuration = 3f;

    private readonly IUnitRegistry _unitRegistry;
    private readonly IDamageCalculator _damageCalculator;
    private readonly IVFxFactory _vfxFactory;

    private bool _started;
    private float _untilNextTurnTick = TurnTickDuration;
    private UnitGroup _lastAttacked;

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

    public void Start()
    {
      _started = true;
      _lastAttacked = UnitGroup.None;
    }
    
    public void Finish()
    {
      _started = false;
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
      
      if (BattleEnded())
        Finish();
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
    
    private bool BattleEnded() => !_unitRegistry.Player.Health.IsAlive || !_unitRegistry.Enemy.Health.IsAlive;
  }
}