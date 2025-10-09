using System.Collections.Generic;
using App.Scripts.Gameplay.Windows.Core;
using App.Scripts.Gameplay.Windows.Win;
using Cysharp.Threading.Tasks;
using Scenes.App.Scripts.Gameplay.Units;
using UnityEngine;

namespace App.Scripts.Gameplay.Windows
{
  public class ChooseUnitWindow : WindowBase<UnitType>
  {
    [SerializeField] private UnitClassSelector _unitClassSelector;
    
    public UniTask<UnitType> ShowAndSetup(List<UnitType> unitTypes)
    {
      _unitClassSelector.Setup(unitTypes, OnUnitTypeChosen);

      return Show();
    }
    
    private void OnUnitTypeChosen(UnitType unitType) => SetResult(unitType);
  }
}