using System;
using ModestTree.Util;
using Scenes.App.Scripts.Gameplay.Units;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.Gameplay.Windows.Core
{
  public class UnitClassButton : MonoBehaviour
  {
    [SerializeField] private TMP_Text _name;
    [SerializeField] private Button _button;
    
    private UnitType _unitType;

    public void Setup(UnitType unitType, string name, Action<UnitType> onClick)
    {
      _unitType = unitType;
      _name.text = name;
      
      _button.onClick.RemoveAllListeners();
      _button.onClick.AddListener(() => onClick(_unitType));
    }
  }
}