using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace App.Scripts.Infrastructure.VFX._Config
{
  [CreateAssetMenu(fileName = "VFxConfig", menuName = "Configs/VFxConfig", order = 1)]
  public class VFxConfig : SerializedScriptableObject
  {
    public Dictionary<VFxType, GameObject> VFx = new Dictionary<VFxType, GameObject>();
  }
}