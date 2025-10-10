using System;
using App.Scripts.Gameplay.Weapons.Data;
using Scenes.App.Scripts.Gameplay.Units;

namespace App.Scripts.Gameplay.Effects.Variants
{
  [Serializable]
  public class SlashResistEffect : Effect
  {
    public override EffectType Type => EffectType.Defence;
    public override bool CanApply(IUnit attacker, IUnit defender, EffectEnvironment environment) => environment.Weapon?.DamageType == DamageType.Slashing;
    public override void Apply(IUnit attacker, IUnit defender, EffectEnvironment environment)
    {
      environment.DamageAdditive -= environment.WeaponDamage;
    }
    
    public override string ToString(IUnit attacker, IUnit defender, EffectEnvironment environment) => $"Bludgeon resist weapon damage ({environment.Damage} -> {environment.Damage - environment.WeaponDamage})\n";
  }
}