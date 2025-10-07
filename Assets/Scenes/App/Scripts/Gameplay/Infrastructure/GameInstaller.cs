using Scenes.App.Scripts.Gameplay.Battle;
using Scenes.App.Scripts.Gameplay.UnitRegistryImpl;
using Scenes.App.Scripts.Infrastructure;
using Zenject;

namespace Scenes.App.Scripts.Gameplay.Infrastructure
{
  public class GameInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      Container.BindInterfacesAndSelfTo<BattleConductor>().AsSingle();
      Container.Bind<IUnitRegistry>().To<UnitRegistry>().AsSingle();

      Container.BindInterfacesTo<EntryPoint>().AsSingle();
    }
  }
}