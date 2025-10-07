using Scenes.App.Scripts.Gameplay.Units;
using Scenes.App.Scripts.Gameplay.Units.Config;
using UnityEngine;

namespace Scenes.App.Scripts.Gameplay.Factory
{
  public class HeroFactory : IHeroFactory
  {
    private readonly UnitsConfig _unitsConfig;
    public HeroFactory(UnitsConfig unitsConfig)
    {
      _unitsConfig = unitsConfig;
    }
    
    public Unit CreatePlayer(UnitType playerType, Vector2 at, Vector2 lookTo)
    {
      var unit = CreateBaseUnit(playerType, at, lookTo, _unitsConfig.Players[playerType].Prefab);

      return unit;
    }

    public Unit CreateEnemy(UnitType playerType, Vector2 at, Vector2 lookTo)
    {
      var unit = CreateBaseUnit(playerType, at, lookTo, _unitsConfig.Enemies[playerType].Prefab);

      return unit;
    }
    
    private Unit CreateBaseUnit(UnitType playerType, Vector2 at, Vector2 lookTo, GameObject prefab)
    {
      Unit unit = new Unit();
      UnitView unitView = Object.Instantiate(prefab, at, Quaternion.identity)
        .GetComponent<UnitView>();
      unitView.RotateTo(lookTo - at);
      
      unit.SetView(unitView);
      return unit;
    }
  }
}