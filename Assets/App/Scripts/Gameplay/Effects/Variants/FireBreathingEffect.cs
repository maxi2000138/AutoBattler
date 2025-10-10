using System;
using Scenes.App.Scripts.Gameplay.Units;
using UnityEngine;

namespace App.Scripts.Gameplay.Effects.Variants
{
  [Serializable]
  public class FireBreathingEffect : Effect
  {
    [SerializeField] private int _damageIncrease = 3;
    public override EffectType Type => EffectType.Attack;
    public override bool CanApply(IUnit attacker, IUnit defender, EffectEnvironment environment) => environment.TurnNumber % 3 == 0;
    public override void Apply(IUnit attacker, IUnit defender, EffectEnvironment environment)
    {
      environment.DamageAdditive += _damageIncrease;
    }
    public override string ToString(IUnit attacker, IUnit defender, EffectEnvironment environment) => $"Fire breathing increase damage +{_damageIncrease} ({environment.Damage} -> {environment.Damage + _damageIncrease})\n";
  }
}