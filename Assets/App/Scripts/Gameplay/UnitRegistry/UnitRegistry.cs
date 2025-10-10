using Scenes.App.Scripts.Gameplay.Units;

namespace Scenes.App.Scripts.Gameplay.UnitRegistryImpl
{
  public class UnitRegistry : IUnitRegistry
  {
    public Player Player { get; private set; }
    public Enemy Enemy { get; private set; }
    
    public void RegisterPlayer(Player player)
    {
      Player?.Dispose();
      Player = player;
    }
    
    public void RemovePlayer()
    {
      Player?.Dispose();
      Player = null;
    }
    
    public void RegisterEnemy(Enemy enemy)
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