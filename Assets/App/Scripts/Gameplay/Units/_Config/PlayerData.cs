using System.Collections.Generic;
using App.Scripts.Gameplay.Weapons.Data;
using UnityEngine;

namespace Scenes.App.Scripts.Gameplay.Units.Config
{
  public class PlayerData
  {
    public int HealthByLevel;
    public WeaponType StartWeapon;
    public List<BuffData> LevelBuffs;
    
    public GameObject Prefab;
  }
}