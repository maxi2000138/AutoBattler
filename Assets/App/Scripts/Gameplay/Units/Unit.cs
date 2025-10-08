using System.Collections.Generic;
using App.Scripts.Gameplay.Stats;
using App.Scripts.Gameplay.Units;
using Scenes.App.Scripts.Gameplay.Units.Health;
using UnityEngine;

namespace Scenes.App.Scripts.Gameplay.Units
{
  public class Unit : IUnit
  {
    public UnitHealth Health { get; }
    public Stats Stats { get; }
    public UnitView View { get; private set; }

    private UnitBarsUpdater _barsUpdater;

    public Unit(UnitStatsData statsData)
    {
      Stats = new Stats(
        new Dictionary<StatType, float>
        {
          {StatType.Strength, statsData.Strength},
          {StatType.Agility, statsData.Agility},
          {StatType.Endurance, statsData.Endurance},
        });
      
      Health = new UnitHealth(statsData.Health, statsData.Health);
    }
    
    public void UpdateView(UnitView view)
    {
      if (View != null) 
        ClearBarsSubsribers();
      
      View = view;
      
      _barsUpdater = new UnitBarsUpdater(View.StatBars, View.HealthBar);
      _barsUpdater.UpdateStatBars(Stats.BaseStats);
      _barsUpdater.UpdateHealthBar(Health);
      
      Stats.StatChanged += _barsUpdater.UpdateStatBar;
      Health.HealthChanged += _barsUpdater.UpdateHealthBar;
    }
    
    public void Dispose()
    {
      ClearBarsSubsribers();
      Object.Destroy(View);
    }
    
    private void ClearBarsSubsribers()
    {
      Stats.StatChanged -= _barsUpdater.UpdateStatBar;
      Health.HealthChanged -= _barsUpdater.UpdateHealthBar;
    }
  }
}