using Scenes.App.Scripts.Gameplay.Units;
using UnityEngine;

namespace Scenes.App.Scripts.Gameplay.Factory
{
  public interface IUnitFactory
  {
    Player CreatePlayer(UnitType playerType, int level, Vector2 at, Vector2 lookTo);
    Enemy CreateEnemy(UnitType enemyType, Vector2 at, Vector2 lookTo);
  }
}