using App.Scripts.Gameplay.Weapons._Config;

namespace App.Scripts.Gameplay.Effects
{
  public class EffectEnvironment
  {
    public readonly int Strength;
    public readonly int WeaponDamage;
    public readonly WeaponData Weapon;

    public EffectEnvironment(int strength, int weaponDamage, WeaponData weapon)
    {
      Strength = strength;
      WeaponDamage = weaponDamage;
      Weapon = weapon;
    }

    public int DamageAdditive;
    public int TurnNumber;
    
    public int Damage => Strength + WeaponDamage + DamageAdditive;
  }
}