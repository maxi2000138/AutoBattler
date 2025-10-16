using Scenes.App.Scripts.Gameplay.Units;

namespace App.Scripts.Gameplay.Stats
{
  public interface IStatsFactory
  {
    int PlayerMaxLevel { get; }
    UnitStatsData GetPlayerBaseStats(UnitType unitType);
    UnitStatsData GetEnemyBaseStats(UnitType unitType);
  }
}