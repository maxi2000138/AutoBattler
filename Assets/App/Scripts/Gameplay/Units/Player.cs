using System.Collections.Generic;
using App.Scripts.Gameplay.Weapons.Data;

namespace Scenes.App.Scripts.Gameplay.Units
{
  public class Player : Unit
  {
    public int Level { get; private set; }
    public int MaxLevel { get; private set; }
    public WeaponType WeaponType { get; private set; }

    private Dictionary<UnitType, int> _unitTypes;
    
    public Player(UnitType unitType, UnitStatsData statsData, int maxLevel) : base(unitType, statsData)
    {
      _unitTypes = new Dictionary<UnitType, int>();
      Level = 0;
      MaxLevel = maxLevel;
    }
    
    
    public void SetWeapon(WeaponType weaponType)
    {
      WeaponType = weaponType;
      View.SetWeapon(weaponType);
    }
    
    public void AddUnitTypeAndUpgradeLevel(UnitType unitType)
    {
      Level++;
      
      if (!_unitTypes.TryAdd(unitType, 1))
        _unitTypes[unitType] += 1;
      
      View.UpdateUnitStats(_unitTypes);
    }
    
    public int StatLevel(UnitType unitType) => _unitTypes.GetValueOrDefault(unitType, 0);
  }
}