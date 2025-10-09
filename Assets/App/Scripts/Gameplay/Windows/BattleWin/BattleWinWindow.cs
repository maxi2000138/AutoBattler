using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.Gameplay.Windows.Win

{
  public class BattleWinWindow : WindowBase<bool>
  {
    [SerializeField] private Button _closeButton;
    
    public UniTask<bool> SetupAndShow()
    {
      _closeButton.onClick.RemoveAllListeners();
      _closeButton.onClick.AddListener(() => SetResult(true));
      
      return Show();
    }
  }
}