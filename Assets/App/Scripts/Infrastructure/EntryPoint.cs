using App.Scripts.Gameplay;
using App.Scripts.Gameplay.Windows;
using UnityEngine;
using Zenject;

namespace Scenes.App.Scripts.Infrastructure
{
  public class EntryPoint : IInitializable
  {
    private readonly GameLoop _gameLoop;
    private readonly IWindowRouter _windowRouter;
    public EntryPoint(GameLoop gameLoop, IWindowRouter windowRouter)
    {
      _gameLoop = gameLoop;
      _windowRouter = windowRouter;
    }
    
    public void Initialize()
    {
      _windowRouter.MainWindow.SetupAndShow(isPaused => Time.timeScale = isPaused ? 0 : 1);
      
      _gameLoop.StartGame().Forget();
    }
  }
}