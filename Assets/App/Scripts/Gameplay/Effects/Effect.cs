using System;
using Scenes.App.Scripts.Gameplay.Units;

namespace App.Scripts.Gameplay.Effects
{
  public abstract class Effect
  {
    public abstract EffectType Type { get; }
    
    public abstract bool CanApply(IUnit attacker, IUnit defender, EffectEnvironment environment);
    public abstract void Apply(IUnit attacker, IUnit defender, EffectEnvironment environment);
    
    public abstract string ToString(IUnit attacker, IUnit defender, EffectEnvironment environment);
  }
}