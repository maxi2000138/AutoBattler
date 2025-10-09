using App.Scripts.Gameplay;
using Zenject;

namespace Scenes.App.Scripts.Infrastructure
{
  public class EntryPoint : IInitializable
  {
    private readonly GameLoop _gameLoop;
    public EntryPoint(GameLoop gameLoop)
    {
      _gameLoop = gameLoop;
    }
    
    public void Initialize()
    {
      _gameLoop.StartGame().Forget();
    }
  }
}