using System.Collections.Generic;
using App.Scripts.Gameplay.Effects;
using App.Scripts.Gameplay.Stats;
using App.Scripts.Gameplay.Units;
using Scenes.App.Scripts.Gameplay.Units.Health;
using UnityEngine;

namespace Scenes.App.Scripts.Gameplay.Units
{
  public abstract class Unit : IUnit
  {
    public UnitType UnitType { get; }
    public UnitHealth Health { get; }
    public Stats Stats { get; }
    public EffectsContainer EffectsContainer { get; }

    public UnitView View { get; private set; }
    
    private UnitBarsUpdater _barsUpdater;

    protected Unit(UnitType unitType, UnitStatsData statsData)
    {
      UnitType = unitType;
      Stats = new Stats(
        new Dictionary<StatType, int>
        {
          {StatType.Strength, statsData.Strength},
          {StatType.Agility, statsData.Agility},
          {StatType.Endurance, statsData.Endurance},
        });
      
      Health = new UnitHealth(statsData.Health, statsData.Health);
      EffectsContainer = new EffectsContainer();
    }

    public void Dispose()
    {
      ClearBarsSubsribers();
      
      if(View != null) 
        Object.Destroy(View.gameObject);
    }

    public void UpdateView(UnitView view)
    {
      if (View != null) 
        ClearBarsSubsribers();
      
      View = view;
      View.Reset();
      
      _barsUpdater = new UnitBarsUpdater(View.StatBars, View.HealthBar);
      _barsUpdater.UpdateStatBars(Stats.BaseStats);
      _barsUpdater.UpdateHealthBar(Health);
      
      Stats.StatChanged += _barsUpdater.UpdateStatBar;
      Health.HealthChanged += _barsUpdater.UpdateHealthBar;
    }

    public void AddUnitEffects(List<Effect> effects)
    {
      EffectsContainer.Add(effects);
    }

    public void Attack(IUnit target, int damage)
    {
      View.Attack();
      target.Health.SetCurrentHealth(target.Health.CurrentHealth - damage);
    }

    public void MissAttack(IUnit target)
    {
      View.MissAttack();
    }

    private void ClearBarsSubsribers()
    {
      Stats.StatChanged -= _barsUpdater.UpdateStatBar;
      Health.HealthChanged -= _barsUpdater.UpdateHealthBar;
    }
  }
}