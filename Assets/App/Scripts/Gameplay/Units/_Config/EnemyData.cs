using App.Scripts.Gameplay.Weapons.Data;
using UnityEngine;

namespace Scenes.App.Scripts.Gameplay.Units.Config
{
  public class EnemyData
  {
    public int WeaponDamage;
    public UnitStatsData Stats;
    public BuffData Buff;
    public WeaponType RewardWeapon;
    
    public GameObject Prefab;
  }
}