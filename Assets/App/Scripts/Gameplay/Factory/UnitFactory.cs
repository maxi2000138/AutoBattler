using App.Scripts.Gameplay.Stats;
using App.Scripts.Gameplay.Weapons._Config;
using App.Scripts.Infrastructure.VFX;
using Scenes.App.Scripts.Gameplay.UnitRegistryImpl;
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
    private readonly WeaponsConfig _weaponsConfig;
    private readonly IUnitRegistry _unitRegistry;

    public UnitFactory(UnitsConfig unitsConfig, IStatsFactory statsFactory, IVFxFactory vFxFactory, 
      WeaponsConfig weaponsConfig, IUnitRegistry unitRegistry)
    {
      _unitsConfig = unitsConfig;
      _statsFactory = statsFactory;
      _vFxFactory = vFxFactory;
      _weaponsConfig = weaponsConfig;
      _unitRegistry = unitRegistry;
    }
    
    public Player CreatePlayer(UnitType playerType, Vector2 at, Vector2 lookTo)
    {
      PlayerData playerData = _unitsConfig.Players[playerType];

      var player = new Player(playerType, _statsFactory.GetPlayerBaseStats(playerType));
      SetupBaseUnit(player, at, lookTo, playerData.Prefab);

      UpdatePlayerLevel(playerType, player);
      
      player.SetWeapon(playerData.StartWeapon);
      _unitRegistry.RegisterPlayer(player);

      return player;
    }

    public Enemy CreateEnemy(UnitType enemyType, Vector2 at, Vector2 lookTo)
    {
      EnemyData enemyData = _unitsConfig.Enemies[enemyType];

      var enemy = new Enemy(enemyType, _statsFactory.GetEnemyBaseStats(enemyType));
      SetupBaseUnit(enemy , at, lookTo, enemyData.Prefab);
      
      if(enemyData.Buff is { Effects: not null }) 
        enemy.AddUnitEffects(enemyData.Buff.Effects);

      _unitRegistry.RegisterEnemy(enemy);
      
      return enemy;
    }
    
    public void UpdatePlayerLevel(UnitType unitType, Player player)
    {
      PlayerData playerData = _unitsConfig.Players[unitType];

      int currentStatLevel = player.StatLevel(unitType);
      if (playerData.LevelBuffs.Count >= currentStatLevel+1 && playerData.LevelBuffs[currentStatLevel] is { Effects: not null }) 
        player.AddUnitEffects(playerData.LevelBuffs[currentStatLevel].Effects);
      
      player.AddUnitTypeAndUpgradeLevel(unitType);
    }

    private void SetupBaseUnit(Unit unit, Vector2 at, Vector2 lookTo, GameObject prefab)
    {
      UnitView unitView = Object.Instantiate(prefab, at, Quaternion.identity)
        .GetComponent<UnitView>();
      
      unitView.Construct(_vFxFactory, _weaponsConfig);
      unitView.RotateTo(lookTo - at);
      
      unit.UpdateView(unitView);
    }
  }
}