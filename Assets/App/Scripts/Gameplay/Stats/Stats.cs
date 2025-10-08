using System;
using System.Collections.Generic;

namespace App.Scripts.Gameplay.Stats
{
  public class Stats
  {
    public Dictionary<StatType, float> BaseStats => _baseStats;
    
    private readonly Dictionary<StatType, float> _baseStats;
    private readonly Dictionary<StatType, List<StatModifier>> _statModifiers;
    
    public event Action<StatType, float> StatChanged;

    public Stats(Dictionary<StatType, float> baseStats)
    {
      _baseStats = baseStats;
    }
    
    public float GetStat(StatType statType)
    {
      float result = _baseStats[statType];
      foreach (StatModifier modifier in _statModifiers[statType]) 
        result += modifier.AddedValue;
      
      return result;
    }
    
    public void ApplyModifier(StatModifier modifier)
    {
      if (!_statModifiers.ContainsKey(modifier.StatType))
        _statModifiers[modifier.StatType] = new List<StatModifier>();
      
      _statModifiers[modifier.StatType].Add(modifier);
      
      StatChanged?.Invoke(modifier.StatType, GetStat(modifier.StatType));
    }
    
    public void ResetModifiers()
    {
      _statModifiers.Clear();
    }
  }
}