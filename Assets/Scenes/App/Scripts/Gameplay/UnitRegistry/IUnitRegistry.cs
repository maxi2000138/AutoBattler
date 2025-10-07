using Scenes.App.Scripts.Gameplay.Units;

namespace Scenes.App.Scripts.Gameplay.UnitRegistry
{
  public interface IUnitRegistry
  {
    void RegisterPlayer();
    void RegisterEnemy();
    IUnit Player { get; }
    IUnit Enemy { get; }
    void Cleanup();
  }
}