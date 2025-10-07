using System;
using Scenes.App.Scripts.Gameplay.Battle;
using Scenes.App.Scripts.Gameplay.Factory;
using Scenes.App.Scripts.Gameplay.UnitRegistryImpl;
using Scenes.App.Scripts.Gameplay.Units.Config;
using Scenes.App.Scripts.Infrastructure;
using UnityEngine;
using Zenject;

namespace Scenes.App.Scripts.Gameplay._Infrastructure
{
  public class GameInstaller : MonoInstaller
  {
    [SerializeField] private UnitsConfig _unitsConfig;
    
    public override void InstallBindings()
    {
      Container.Bind<UnitsConfig>().FromInstance(_unitsConfig).AsSingle();
      
      Container.BindInterfacesAndSelfTo<BattleConductor>().AsSingle();
      Container.Bind<IUnitRegistry>().To<UnitRegistry>().AsSingle();
      Container.Bind<IHeroFactory>().To<HeroFactory>().AsSingle();

      Container.BindInterfacesTo<EntryPoint>().AsSingle();
    }
  }
}