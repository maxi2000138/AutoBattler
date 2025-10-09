using App.Scripts.Gameplay.Stats;
using App.Scripts.Infrastructure.VFX;
using Scenes.App.Scripts.Gameplay.Units;
using Scenes.App.Scripts.Gameplay.Units.Config;
using UnityEngine;

namespace Scenes.App.Scripts.Gameplay.Factory
{
  public class UnitFactory : IUnitFactory
  {
    private readonly UnitsConfig _unitsConfig;
    private readonly IStatsFactory _statsFactory;
    private readonly IVFxFactory _vFxFactory;

    public UnitFactory(UnitsConfig unitsConfig, IStatsFactory statsFactory, IVFxFactory vFxFactory)
    {
      _unitsConfig = unitsConfig;
      _statsFactory = statsFactory;
      _vFxFactory = vFxFactory;
    }
    
    public Player CreatePlayer(UnitType playerType, int level, Vector2 at, Vector2 lookTo)
    {
      PlayerData playerData = _unitsConfig.Players[playerType];

      var player = new Player(playerType, _statsFactory.GetPlayerBaseStats(playerType));
      SetupBaseUnit(player, at, lookTo, playerData.Prefab);
      
      if(playerData.LevelBuffs.Count >= level) 
        player.EffectsContainer.Add(playerData.LevelBuffs[level-1].Effects);

      return player;
    }

    public Enemy CreateEnemy(UnitType enemyType, Vector2 at, Vector2 lookTo)
    {
      EnemyData enemyData = _unitsConfig.Enemies[enemyType];

      var enemy = new Enemy(enemyType, _statsFactory.GetEnemyBaseStats(enemyType));
      SetupBaseUnit(enemy , at, lookTo, enemyData.Prefab);
      
      enemy.EffectsContainer.Add(enemyData.Buff.Effects);

      return enemy;
    }
    
    private void SetupBaseUnit(Unit unit, Vector2 at, Vector2 lookTo, GameObject prefab)
    {
      UnitView unitView = Object.Instantiate(prefab, at, Quaternion.identity)
        .GetComponent<UnitView>();
      
      unitView.Construct(_vFxFactory);
      unitView.RotateTo(lookTo - at);
      
      unit.UpdateView(unitView);
    }
  }
}