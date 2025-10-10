using System;
using App.Scripts.Gameplay;
using App.Scripts.Gameplay.Stats;
using App.Scripts.Gameplay.Weapons._Config;
using App.Scripts.Gameplay.Windows;
using App.Scripts.Infrastructure.VFX;
using App.Scripts.Infrastructure.VFX._Config;
using Scenes.App.Scripts.Gameplay.Battle;
using Scenes.App.Scripts.Gameplay.Factory;
using Scenes.App.Scripts.Gameplay.UnitRegistryImpl;
using Scenes.App.Scripts.Gameplay.Units.Config;
using Scenes.App.Scripts.Infrastructure;
using TMPro;
using UnityEngine;
using Zenject;

namespace Scenes.App.Scripts.Gameplay._Infrastructure
{
  public class GameInstaller : MonoInstaller
  {
    [Header("Configs")]
    [SerializeField] private UnitsConfig _unitsConfig;
    [SerializeField] private WeaponsConfig _weaponConfig;
    [SerializeField] private VFxConfig _vfxConfig;
    
    [Header("Services")]
    [SerializeField] private WindowRouter _windowRouter;
    
    public override void InstallBindings()
    {
      Container.Bind<UnitsConfig>().FromInstance(_unitsConfig).AsSingle();
      Container.Bind<WeaponsConfig>().FromInstance(_weaponConfig).AsSingle();
      Container.Bind<VFxConfig>().FromInstance(_vfxConfig).AsSingle();
      
      Container.Bind<IWindowRouter>().To<WindowRouter>().FromInstance(_windowRouter).AsSingle();
      Container.Bind<IDamageLogger>().To<DamageLogger>().AsSingle();
      Container.BindInterfacesAndSelfTo<BattleConductor>().AsSingle();
      Container.Bind<IDamageCalculator>().To<DamageCalculator>().AsSingle();
      Container.Bind<IUnitRegistry>().To<UnitRegistry>().AsSingle();
      Container.Bind<IUnitFactory>().To<UnitFactory>().AsSingle();
      Container.Bind<IStatsFactory>().To<StatsFactory>().AsSingle();
      Container.Bind<IVFxFactory>().To<VFxFactory>().AsSingle();

      Container.BindInterfacesTo<EntryPoint>().AsSingle();
      Container.BindInterfacesAndSelfTo<GameLoop>().AsSingle();
    }
  }
}