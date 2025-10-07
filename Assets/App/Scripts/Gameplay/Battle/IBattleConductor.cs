using Zenject;

namespace Scenes.App.Scripts.Gameplay.Battle
{
  public interface IBattleConductor : ITickable
  {
    void Start();
    void Finish();
  }
}