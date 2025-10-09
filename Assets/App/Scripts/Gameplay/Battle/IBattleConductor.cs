using Zenject;

namespace Scenes.App.Scripts.Gameplay.Battle
{
  public interface IBattleConductor : ITickable
  {
    bool IsBattleStarted { get; }
    bool IsBattleEnded { get; }
    bool IsBattleWin { get; }
    void Start();
    void Reset();
  }
}