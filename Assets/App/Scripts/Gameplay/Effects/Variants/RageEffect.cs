using System;
using Scenes.App.Scripts.Gameplay.Units;
using UnityEngine;

namespace App.Scripts.Gameplay.Effects.Variants
{
  [Serializable]
  public class RageEffect : Effect
  {
    [SerializeField] private int _increaseTurns = 3;
    [SerializeField] private int _damageIncrease = 2;
    [SerializeField] private int _damageDecrease = 1;
    
    public override EffectType Type => EffectType.Attack;
    public override bool CanApply(IUnit attacker, IUnit defender, EffectEnvironment environment) => true;
    public override void Apply(IUnit attacker, IUnit defender, EffectEnvironment environment)
    {
      if(IncreaseDamage(environment))
        environment.DamageAdditive += _damageIncrease;
      else
        environment.DamageAdditive -= _damageDecrease;
    }

    public override string ToString(IUnit attacker, IUnit defender, EffectEnvironment environment)
    {
      if(IncreaseDamage(environment))
        return $"Rage increase damage +{_damageIncrease} ({environment.Damage} -> {environment.Damage + _damageIncrease})\n";
      
      return $"Rage decrease damage -{_damageDecrease} ({environment.Damage} -> {environment.Damage - _damageDecrease})\n";
    }
    
    private bool IncreaseDamage(EffectEnvironment environment) => environment.TurnNumber <= _increaseTurns;
    
  }
}