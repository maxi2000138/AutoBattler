using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scenes.App.Scripts.Gameplay.Units.Config
{
  [CreateAssetMenu(fileName = "UnitsConfig", menuName = "Configs/UnitsConfig", order = 1)]
  public class UnitsConfig : SerializedScriptableObject
  {
    public Dictionary<UnitType, PlayerData> Players;
    public Dictionary<UnitType, EnemyData> Enemies;
  }
}