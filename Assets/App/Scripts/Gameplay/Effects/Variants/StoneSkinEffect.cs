using System;
using App.Scripts.Gameplay.Stats;
using Scenes.App.Scripts.Gameplay.Units;

namespace App.Scripts.Gameplay.Effects.Variants
{
  [Serializable]
  public class StoneSkinEffect : Effect
  {
    public override EffectType Type => EffectType.Defence;
    public override bool CanApply(IUnit attacker, IUnit defender, EffectEnvironment environment) => true;
    public override void Apply(IUnit attacker, IUnit defender, EffectEnvironment environment)
    {
      environment.DamageAdditive -= defender.Stats.GetStat(StatType.Endurance);
    }
    
    public override string ToString(IUnit attacker, IUnit defender, EffectEnvironment environment) => $"Stone skin decrease damage ({environment.Damage} -> {environment.Damage - defender.Stats.GetStat(StatType.Endurance)})\n";
  }
}