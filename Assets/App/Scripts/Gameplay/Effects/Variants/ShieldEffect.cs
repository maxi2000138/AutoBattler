using System;
using App.Scripts.Gameplay.Stats;
using Scenes.App.Scripts.Gameplay.Units;
using UnityEngine;

namespace App.Scripts.Gameplay.Effects.Variants
{
  [Serializable]
  public class ShieldEffect : Effect
  {
    [SerializeField] private int _damageDecrease = 3;
    public override EffectType Type => EffectType.Defence;
    public override bool CanApply(IUnit attacker, IUnit defender, EffectEnvironment environment) => 
      defender.Stats.GetStat(StatType.Strength) > attacker.Stats.GetStat(StatType.Strength);
    
    public override void Apply(IUnit attacker, IUnit defender, EffectEnvironment environment)
    {
      if(Mathf.Abs(_damageDecrease) > environment.Damage)
        environment.DamageAdditive = 0;
      else 
        environment.DamageAdditive -=_damageDecrease;
    }
    
    public override string ToString(IUnit attacker, IUnit defender, EffectEnvironment environment) => $"Shield decrease damage ({environment.Damage} -> {environment.Damage - 3})\n";
  }
}