using System;
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
  
    private bool _started;
    private float _untilNextTurnTick;
    private UnitType _lastAttacked;

    public BattleConductor(IUnitRegistry unitRegistry)
    {
      _unitRegistry = unitRegistry;
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
      _lastAttacked = UnitType.None;
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
      if(_lastAttacked == UnitType.None)
        ChooseFirstAttacker();

      if (_lastAttacked == UnitType.Player)
      {
        _lastAttacked = UnitType.Enemy;
        ProcessAttack(attacker: _unitRegistry.Enemy, defender: _unitRegistry.Player);
      }
      else if (_lastAttacked == UnitType.Enemy)
      {
        _lastAttacked = UnitType.Player;
        ProcessAttack(attacker: _unitRegistry.Player, defender: _unitRegistry.Enemy);
      }
    }
    
    private void ChooseFirstAttacker()
    {
      _lastAttacked = UnitType.Enemy;
    }

    private void ProcessAttack(IUnit attacker, IUnit defender)
    {
      Debug.Log($"{attacker} attacks {defender}");
    }
  }
}