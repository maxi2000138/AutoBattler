using System;
using App.Scripts.Gameplay.Stats;
using Scenes.App.Scripts.Gameplay.Units;
using UnityEngine;

namespace App.Scripts.Gameplay.Effects.Variants
{
  [Serializable]
  public class HiddenAttackEffect : Effect
  {
    [SerializeField] private int _damageIncrease = 1;
    public override EffectType Type => EffectType.Attack;
    public override bool CanApply(IUnit attacker, IUnit defender, EffectEnvironment environment)
    {
      return attacker.Stats.GetStat(StatType.Agility) > defender.Stats.GetStat(StatType.Agility);
    }
    
    public override void Apply(IUnit attacker, IUnit defender, EffectEnvironment environment)
    { 
      environment.DamageAdditive += _damageIncrease;
    }
    
    public override string ToString(IUnit attacker, IUnit defender, EffectEnvironment environment) => $"Hidden attack increase damage +1 ({environment.Damage} -> {environment.Damage + 1})\n";
  }
}