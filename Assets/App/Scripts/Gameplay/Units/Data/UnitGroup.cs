namespace Scenes.App.Scripts.Gameplay.Units
{
  public enum UnitGroup : byte
  {
    None = 0,
    
    Player = 1,
    Enemy = 2,
  }
  
  public enum UnitType
  {
    None = 0,
    
    Robber = 1,
    Warrior = 2,
    Barbarian = 3,
    
    Goblin = 101,
    Skeleton = 102,
    Slime = 103,
    Ghost = 104,
    Golem = 105,
    Dragon = 106,
  }
}