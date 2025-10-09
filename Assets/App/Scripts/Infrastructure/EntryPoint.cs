using System;
using App.Scripts.Gameplay.Weapons.Data;
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
    private readonly IUnitFactory _unitFactory;

    public EntryPoint(IBattleConductor battleConductor, IUnitRegistry unitRegistry, 
      IUnitFactory unitFactory)
    {
      _battleConductor = battleConductor;
      _unitRegistry = unitRegistry;
      _unitFactory = unitFactory;
    }
    
    public void Initialize()
    {
      var player = _unitFactory.CreatePlayer(UnitType.Barbarian, level: 1, at: _leftUnitPosition, lookTo: _centre);
      player.SetWeapon(WeaponType.Sword);
      
      var enemy = _unitFactory.CreateEnemy(UnitType.Goblin, at: _rightUnitPosition, lookTo: _centre);
      
      _unitRegistry.RegisterPlayer(player);
      _unitRegistry.RegisterEnemy(enemy);
      
      _battleConductor.Start();
    }
    
    public void Dispose()
    {
      _battleConductor.Finish();
    }
  }
}