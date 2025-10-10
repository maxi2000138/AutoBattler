using Scenes.App.Scripts.Gameplay.Units;

namespace App.Scripts.Gameplay.Effects
{
  public abstract class Effect
  {
    public abstract EffectType Type { get; }
    
    public abstract bool CanApply(IUnit attacker, IUnit defender);
    public abstract int Apply(IUnit attacker, IUnit defender, float damage);
    
    public abstract string ToString(float damage);
  }
}