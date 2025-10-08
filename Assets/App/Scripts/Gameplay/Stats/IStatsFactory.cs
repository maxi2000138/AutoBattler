using Scenes.App.Scripts.Gameplay.Units;

namespace App.Scripts.Gameplay.Stats
{
  public interface IStatsFactory
  {
    UnitStatsData GetPlayerBaseStats(UnitType unitType);
    UnitStatsData GetEnemyBaseStats(UnitType unitType);
  }
}