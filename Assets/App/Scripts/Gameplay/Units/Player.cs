using App.Scripts.Gameplay.Weapons.Data;

namespace Scenes.App.Scripts.Gameplay.Units
{
  public class Player : Unit
  {
    public WeaponType WeaponType { get; private set; }

    public Player(UnitType unitType, UnitStatsData statsData) : base(unitType, statsData) { }
    
    public void SetWeapon(WeaponType weaponType)
    {
      WeaponType = weaponType;
    }
  }
}