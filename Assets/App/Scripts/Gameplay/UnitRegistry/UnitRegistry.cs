using Scenes.App.Scripts.Gameplay.Units;

namespace Scenes.App.Scripts.Gameplay.UnitRegistryImpl
{
  public class UnitRegistry : IUnitRegistry
  {
    public IUnit Player { get; private set; }
    public IUnit Enemy { get; private set; }
    
    public void RegisterPlayer(IUnit player)
    {
      Player?.Dispose();
      Player = player;
    }
    
    public void RemovePlayer()
    {
      Player?.Dispose();
      Player = null;
    }
    
    public void RegisterEnemy(IUnit enemy)
    {
      Enemy?.Dispose();
      Enemy = enemy;
    }
    
    public void RemoveEnemy()
    {
      Enemy?.Dispose();
      Enemy = null;
    }

    public void Cleanup()
    {
      Player?.Dispose();
      Enemy?.Dispose();
      
      Player = null;
      Enemy = null;
    }
  }
}