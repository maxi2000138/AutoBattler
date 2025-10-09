using System;
using System.Collections.Generic;
using App.Scripts.Gameplay.Effects;
using App.Scripts.Gameplay.Stats;

namespace Scenes.App.Scripts.Gameplay.Units.Config
{
  [Serializable]
  public class BuffData
  {
    public List<Effect> Effects;
    public List<StatModifier> StatModifiers;
  }
}