using App.Scripts.Gameplay.Windows.Win;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.Gameplay.Windows
{
  public class GameWinWindow : WindowBase<bool>
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