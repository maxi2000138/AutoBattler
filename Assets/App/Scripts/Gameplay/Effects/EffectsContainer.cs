using System.Collections.Generic;
using System.Linq;

namespace App.Scripts.Gameplay.Effects
{
  public class EffectsContainer
  {
    public IEnumerable<Effect> AttackEffects => _effects.Where(x => x.Type == EffectType.Attack);
    public IEnumerable<Effect> DefenceEffects => _effects.Where(x => x.Type == EffectType.Defence);
    
    private List<Effect> _effects = new List<Effect>();

    public void Add(IEnumerable<Effect> effects)
    {
      foreach (var effect in effects)
        Add(effect);
    }
    
    public void Add(Effect effect)
    {
      _effects.Add(effect);
    }
    
    public void Remove(Effect effect)
    {
      _effects.Remove(effect);
    }
    
    public void Clear()
    {
      _effects.Clear();
    }
  }
}