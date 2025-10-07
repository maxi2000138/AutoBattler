using Scenes.App.Scripts.Gameplay.Units;
using UnityEngine;

namespace Scenes.App.Scripts.Gameplay.Factory
{
  public interface IHeroFactory
  {
    Unit CreatePlayer(UnitType playerType, Vector2 at, Vector2 lookTo);
    Unit CreateEnemy(UnitType playerType, Vector2 at, Vector2 lookTo);
  }
}