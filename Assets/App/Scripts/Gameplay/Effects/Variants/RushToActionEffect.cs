using System;
using Scenes.App.Scripts.Gameplay.Units;
using UnityEngine;

namespace App.Scripts.Gameplay.Effects.Variants
{
  [Serializable]
  public class RushToActionEffect : Effect
  {
    [SerializeField] private int _weaponDamageScale = 2;
    public override EffectType Type => EffectType.Attack;
    public override bool CanApply(IUnit attacker, IUnit defender, EffectEnvironment environment) => environment.TurnNumber == 1;
    public override void Apply(IUnit attacker, IUnit defender, EffectEnvironment environment)
    {
      environment.DamageAdditive += environment.WeaponDamage * (_weaponDamageScale - 1);
    }
    public override string ToString(IUnit attacker, IUnit defender, EffectEnvironment environment) => $"Rush to action scale weapon damage by {_weaponDamageScale}: +{environment.WeaponDamage} ({environment.Damage} -> {environment.Damage + environment.WeaponDamage})\n";
  }
}