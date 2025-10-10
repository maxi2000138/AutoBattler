using System;
using App.Scripts.Gameplay.Windows.Win;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.Gameplay.Windows.Main
{
  public class MainWindow : WindowBase
  {
    [SerializeField] private Button _pauseButton;
    [SerializeField] private TMP_Text _mainText;
    
    private bool _isPaused = false;
    
    private Action<bool> _onPauseClick;

    public void SetupAndShow(Action<bool> onPauseClick)
    {
      _onPauseClick = onPauseClick;
      _pauseButton.onClick.RemoveAllListeners();
      _pauseButton.onClick.AddListener(OnPauseClick);
      
      UpdateMainInfo("");
      
      Show();
    }
    
    public void UpdateMainInfo(string mainInfoText) =>
      _mainText.text = mainInfoText;

    private void OnPauseClick()
    {
      _isPaused = !_isPaused;
      _onPauseClick(_isPaused);
    }
  }
}