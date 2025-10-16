using Scenes.App.Scripts.Gameplay.Units;
using Scenes.App.Scripts.Gameplay.Units.Config;
using UnityEngine;

namespace App.Scripts.Gameplay.Stats
{
  public class StatsFactory : IStatsFactory
  {
    public int PlayerMaxLevel => 3;

    private readonly UnitsConfig _unitsConfig;
    
    private int PlayerRandomBaseStat() => Random.Range(1, 4);
    
    public StatsFactory(UnitsConfig unitsConfig)
    {
      _unitsConfig = unitsConfig;
    }
    
    public UnitStatsData GetPlayerBaseStats(UnitType unitType)
    {
      var stats = new UnitStatsData()
      {
        Strength = PlayerRandomBaseStat(),
        Agility = PlayerRandomBaseStat(),
        Endurance = PlayerRandomBaseStat(),
      };
      
      stats.Health = _unitsConfig.Players[unitType].HealthByLevel + stats.Endurance;
      return stats;
    }
    
    public UnitStatsData GetEnemyBaseStats(UnitType unitType)
    {
      return _unitsConfig.Enemies[unitType].Stats;
    }
  }
}