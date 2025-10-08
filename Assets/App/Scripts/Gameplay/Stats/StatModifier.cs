using System;

namespace App.Scripts.Gameplay.Stats
{
  [Serializable]
  public class StatModifier
  {
    public StatType StatType;
    public int AddedValue;
  }
}