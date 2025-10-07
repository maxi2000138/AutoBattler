using System;
using Scenes.App.Scripts.Gameplay.Battle;
using Scenes.App.Scripts.Gameplay.Factory;
using Scenes.App.Scripts.Gameplay.UnitRegistryImpl;
using Scenes.App.Scripts.Gameplay.Units;
using UnityEngine;
using Zenject;

namespace Scenes.App.Scripts.Infrastructure
{
  public class EntryPoint : IInitializable, IDisposable
  {
    private readonly Vector2 _leftUnitPosition = new Vector2(-5, -2);
    private readonly Vector2 _rightUnitPosition = new Vector2(5, -2);
    private readonly Vector2 _centre = Vector2.zero;
    
    private readonly IBattleConductor _battleConductor;
    private readonly IUnitRegistry _unitRegistry;
    private readonly IHeroFactory _heroFactory;

    public EntryPoint(IBattleConductor battleConductor, IUnitRegistry unitRegistry, 
      IHeroFactory heroFactory)
    {
      _battleConductor = battleConductor;
      _unitRegistry = unitRegistry;
      _heroFactory = heroFactory;
    }
    
    public void Initialize()
    {
      _unitRegistry.RegisterPlayer(_heroFactory.CreatePlayer(UnitType.Barbarian, at: _leftUnitPosition, lookTo: _centre));
      _unitRegistry.RegisterEnemy(_heroFactory.CreateEnemy(UnitType.Goblin, at: _rightUnitPosition, lookTo: _centre));
      
      _battleConductor.Start();
    }
    
    public void Dispose()
    {
      _battleConductor.Finish();
    }
  }
}