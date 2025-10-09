using App.Scripts.Gameplay.Windows.ChangeWeapon;
using App.Scripts.Gameplay.Windows.Loose;
using App.Scripts.Gameplay.Windows.Win;

namespace App.Scripts.Gameplay.Windows
{
  public interface IWindowRouter
  {
    GameWinWindow GameWinWindow { get; }
    BattleWinWindow BattleWinWindow { get; }
    LooseWindow LooseWindow { get; }
    ChangeWeaponWindow ChangeWeaponWindow { get; }
    ChooseUnitWindow ChooseUnitWindow { get; }
  }
}