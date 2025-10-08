
using System;
using App.Scripts.Gameplay.Stats;

namespace Scenes.App.Scripts.Gameplay.Units
{
  public interface IUnit : IDisposable
  {
    Stats Stats { get; }
    UnitView View { get; }
  }
}