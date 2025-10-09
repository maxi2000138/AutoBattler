using System.Collections.Generic;
using App.Scripts.Gameplay.Stats;
using App.Scripts.Utils;
using Scenes.App.Scripts.Gameplay.Units.Health;

namespace App.Scripts.Gameplay.Units
{
  public class UnitBarsUpdater
  {
    private readonly Dictionary<StatType, UnitBar> _statBars;
    private readonly UnitBar _healthBar;
    
    public UnitBarsUpdater(Dictionary<StatType, UnitBar> statBars, UnitBar healthBar)
    {
      _statBars = statBars;
      _healthBar = healthBar;
    }

    public void UpdateStatBars(Dictionary<StatType, int> baseStats)
    {
      foreach (var bar in _statBars)
      {
        if(baseStats.TryGetValue(bar.Key, out var value))
          UpdateStatBar(bar.Key, value);
      }
    }

    public void UpdateStatBar(StatType statType, int value)
    {
      _statBars[statType].Text.text = statType + ": " + value;
      _statBars[statType].Fill.fillAmount = 1;
    }
    
    public void UpdateHealthBar(UnitHealth health)
    {
      float fillAmount = Mathematics.Remap(0, health.MaxHealth, 0, 1, health.CurrentHealth);

      _healthBar.Text.text = health.ToString();
      _healthBar.Fill.fillAmount = fillAmount;
    }
  }
}