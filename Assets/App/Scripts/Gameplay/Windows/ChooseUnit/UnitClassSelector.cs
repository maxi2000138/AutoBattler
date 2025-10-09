using System;
using System.Collections.Generic;
using Scenes.App.Scripts.Gameplay.Units;
using UnityEngine;

namespace App.Scripts.Gameplay.Windows.Core
{
  public class UnitClassSelector : MonoBehaviour
  {
    [SerializeField] private UnitClassButton _prefab;
    
    private readonly List<UnitClassButton> _buttons = new List<UnitClassButton>();

    public void Setup(List<UnitType> unitTypes, Action<UnitType> onClick)
    {
      foreach (var button in _buttons) 
        Destroy(button.gameObject);
      _buttons.Clear();
      
      foreach (UnitType unitType in unitTypes)
      {
        var button = Instantiate(_prefab, transform);
        button.gameObject.SetActive(true);
        button.Setup(unitType, unitType.ToString(), onClick);
        _buttons.Add(button);
      }
    }
  }
}