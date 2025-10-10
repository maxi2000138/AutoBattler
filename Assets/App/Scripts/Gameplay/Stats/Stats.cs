using System;
using System.Collections.Generic;

namespace App.Scripts.Gameplay.Stats
{
  public class Stats
  {
    public Dictionary<StatType, int> BaseStats => _baseStats;
    
    private readonly Dictionary<StatType, int> _baseStats;
    private readonly Dictionary<StatType, List<StatModifier>> _statModifiers;
    
    public event Action<StatType, int> StatChanged;

    public Stats(Dictionary<StatType, int> baseStats)
    {
      _baseStats = baseStats;
      _statModifiers = new Dictionary<StatType, List<StatModifier>>();
    }
    
    public int GetStat(StatType statType)
    {
      int result = _baseStats[statType];
      
      if (!_statModifiers.ContainsKey(statType)) 
        return result;
      
      foreach (StatModifier modifier in _statModifiers[statType]) 
        result += modifier.AddedValue;
      
      return result;
    }
    
    public void ApplyModifiers(List<StatModifier> modifiers) => modifiers.ForEach(ApplyModifier);

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