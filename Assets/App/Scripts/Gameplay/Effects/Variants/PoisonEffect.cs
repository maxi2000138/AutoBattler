using System;
using Scenes.App.Scripts.Gameplay.Units;

namespace App.Scripts.Gameplay.Effects.Variants
{
  [Serializable]
  public class PoisonEffect : Effect
  {
    public override EffectType Type => EffectType.Attack;
    public override bool CanApply(IUnit attacker, IUnit defender, EffectEnvironment environment) => environment.TurnNumber > 1;
    public override void Apply(IUnit attacker, IUnit defender, EffectEnvironment environment)
    {
      environment.DamageAdditive += ExtraDamage(environment);
    }
    
    public override string ToString(IUnit attacker, IUnit defender, EffectEnvironment environment) =>
      $"Poison increase damage +{ExtraDamage(environment)} ({environment.Damage} -> {environment.Damage + ExtraDamage(environment)})\n";
    
    private int ExtraDamage(EffectEnvironment environment) => environment.TurnNumber - 1;
  }
}