using Scenes.App.Scripts.Gameplay.Units;

namespace Scenes.App.Scripts.Gameplay.UnitRegistryImpl
{
  public interface IUnitRegistry
  {
    void RegisterPlayer(IUnit player);
    void RegisterEnemy(IUnit enemy);
    IUnit Player { get; }
    IUnit Enemy { get; }
    void Cleanup();
  }
}