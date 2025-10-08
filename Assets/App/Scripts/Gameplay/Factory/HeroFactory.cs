using App.Scripts.Gameplay.Stats;
using Scenes.App.Scripts.Gameplay.Units;
using Scenes.App.Scripts.Gameplay.Units.Config;
using UnityEngine;

namespace Scenes.App.Scripts.Gameplay.Factory
{
  public class HeroFactory : IHeroFactory
  {
    private readonly UnitsConfig _unitsConfig;
    private readonly IStatsFactory _statsFactory;
    
    public HeroFactory(UnitsConfig unitsConfig, IStatsFactory statsFactory)
    {
      _unitsConfig = unitsConfig;
      _statsFactory = statsFactory;
    }
    
    public Unit CreatePlayer(UnitType playerType, Vector2 at, Vector2 lookTo)
    {
      var unit = CreateBaseUnit(_statsFactory.GetPlayerBaseStats(playerType), at, lookTo, 
        _unitsConfig.Players[playerType].Prefab);

      return unit;
    }

    public Unit CreateEnemy(UnitType enemyType, Vector2 at, Vector2 lookTo)
    {
      var unit = CreateBaseUnit(_statsFactory.GetEnemyBaseStats(enemyType), at, lookTo, 
        _unitsConfig.Enemies[enemyType].Prefab);

      return unit;
    }
    
    private Unit CreateBaseUnit(UnitStatsData unitStats, Vector2 at, Vector2 lookTo, GameObject prefab)
    {
      Unit unit = new Unit(unitStats);
      UnitView unitView = Object.Instantiate(prefab, at, Quaternion.identity)
        .GetComponent<UnitView>();
      unitView.RotateTo(lookTo - at);
      
      unit.UpdateView(unitView);
      return unit;
    }
  }
}