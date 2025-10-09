using App.Scripts.Gameplay.Weapons.Data;
using App.Scripts.Gameplay.Windows.Win;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.Gameplay.Windows.ChangeWeapon
{
  public class ChangeWeaponWindow : WindowBase<bool>
  {
    [SerializeField] private TMP_Text _mainInfoText;
    
    [SerializeField] private Button _cancelButton;
    [SerializeField] private Button _changeButton;
    
    
    public UniTask<bool> SetupAndShow(WeaponType weaponType)
    {
      _mainInfoText.text = MainInfoText(weaponType);
      
      _cancelButton.onClick.RemoveAllListeners();
      _cancelButton.onClick.AddListener(() => SetResult(false));
      
      _changeButton.onClick.RemoveAllListeners();
      _changeButton.onClick.AddListener(() => SetResult(true));
      
      return Show();
    }
    
    private string MainInfoText(WeaponType weaponType) => $"The {weaponType} has fallen from the enemy, must be picked?";
  }
}