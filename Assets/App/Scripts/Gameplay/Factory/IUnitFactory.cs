using Scenes.App.Scripts.Gameplay.Units;
using Scenes.App.Scripts.Gameplay.Units.Config;
using UnityEngine;

namespace Scenes.App.Scripts.Gameplay.Factory
{
  public interface IUnitFactory
  {
    Player CreatePlayer(UnitType playerType, Vector2 at, Vector2 lookTo);
    Enemy CreateEnemy(UnitType enemyType, Vector2 at, Vector2 lookTo);
    void UpdatePlayerLevel(UnitType unitType, Player player);
  }
}