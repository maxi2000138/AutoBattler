using Scenes.App.Scripts.Gameplay.Units;

namespace Scenes.App.Scripts.Gameplay.UnitRegistryImpl
{
  public interface IUnitRegistry
  {
    void RegisterPlayer(Player player);
    void RegisterEnemy(Enemy enemy);
    void RemovePlayer();
    void RemoveEnemy();
    Player Player { get; }
    Enemy Enemy { get; }
    void Cleanup();
  }
}