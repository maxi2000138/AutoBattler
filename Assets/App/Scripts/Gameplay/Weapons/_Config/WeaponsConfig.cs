using System.Collections.Generic;
using App.Scripts.Gameplay.Weapons.Data;
using Sirenix.OdinInspector;
using UnityEngine;

namespace App.Scripts.Gameplay.Weapons._Config
{
  [CreateAssetMenu(fileName = "WeaponsConfig", menuName = "Configs/WeaponsConfig", order = 1)]
  public class WeaponsConfig : SerializedScriptableObject
  {
    public Dictionary<WeaponType, WeaponData> Weapons;
  }
}