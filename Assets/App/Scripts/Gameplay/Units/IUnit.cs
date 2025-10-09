using System;
using App.Scripts.Gameplay.Effects;
using App.Scripts.Gameplay.Stats;
using Scenes.App.Scripts.Gameplay.Units.Health;

namespace Scenes.App.Scripts.Gameplay.Units
{
  public interface IUnit : IDisposable
  {
    UnitType UnitType { get; }
    UnitHealth Health { get; }
    UnitView View { get; }
    Stats Stats { get; }
    public EffectsContainer EffectsContainer { get; }
    
    void Attack(IUnit target, int damage);
    void MissAttack(IUnit target);
  }
}