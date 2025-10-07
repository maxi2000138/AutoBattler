using System;
using Scenes.App.Scripts.Gameplay.Battle;
using Scenes.App.Scripts.Gameplay.UnitRegistryImpl;
using Scenes.App.Scripts.Gameplay.Units;
using Zenject;

namespace Scenes.App.Scripts.Infrastructure
{
  public class EntryPoint : IInitializable, IDisposable
  {
    private readonly IBattleConductor _battleConductor;
    private readonly IUnitRegistry _unitRegistry;
    
    public EntryPoint(IBattleConductor battleConductor, IUnitRegistry unitRegistry)
    {
      _battleConductor = battleConductor;
      _unitRegistry = unitRegistry;
    }
    
    public void Initialize()
    {
      _unitRegistry.RegisterPlayer(new Unit());
      _unitRegistry.RegisterEnemy(new Unit());
      
      _battleConductor.Start();
    }
    
    public void Dispose()
    {
      _battleConductor.Finish();
    }
  }
}