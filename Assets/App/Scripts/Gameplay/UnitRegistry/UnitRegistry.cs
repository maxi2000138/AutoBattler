using Scenes.App.Scripts.Gameplay.Units;

namespace Scenes.App.Scripts.Gameplay.UnitRegistryImpl
{
  public class UnitRegistry : IUnitRegistry
  {
    public IUnit Player { get; private set; }
    public IUnit Enemy { get; private set; }
    public void RegisterPlayer(IUnit player)
    {
      Player = player;
    }
    
    public void RegisterEnemy(IUnit enemy)
    {
      Enemy = enemy;
    }

    public void Cleanup()
    {
      Player = null;
      Enemy = null;
    }
  }
}