using App.Scripts.Gameplay.Windows.ChangeWeapon;
using App.Scripts.Gameplay.Windows.Loose;
using App.Scripts.Gameplay.Windows.Win;
using UnityEngine;
using UnityEngine.Serialization;

namespace App.Scripts.Gameplay.Windows
{
  public class WindowRouter : MonoBehaviour, IWindowRouter
  {
    [field: SerializeField] public GameWinWindow GameWinWindow { get; private set; }
    [field: SerializeField] public BattleWinWindow BattleWinWindow { get; private set; }
    [field: SerializeField] public LooseWindow LooseWindow { get; private set; }
    [field: SerializeField] public ChangeWeaponWindow ChangeWeaponWindow { get; private set; }
    [field: SerializeField] public ChooseUnitWindow ChooseUnitWindow { get; private set; }
  }
}