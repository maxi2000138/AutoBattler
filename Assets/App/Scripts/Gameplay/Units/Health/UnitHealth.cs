using System;
using UnityEngine;

namespace Scenes.App.Scripts.Gameplay.Units.Health
{
  public class UnitHealth
  {
    public int MaxHealth { get; private set; }
    public int CurrentHealth { get; private set; }
    
    public event Action<UnitHealth> HealthChanged;
  
    public bool IsAlive => CurrentHealth > 0;

    public void SetMaxHealth(int maxHealth) => MaxHealth = maxHealth;
    public void SetCurrentHealth(int currentHealth)
    {
      CurrentHealth = currentHealth;
      HealthChanged?.Invoke(this);
    }

    public UnitHealth(int currentHealth, int maxHealth)
    {
      SetMaxHealth(maxHealth);
      SetCurrentHealth(currentHealth);
    }

    public override string ToString() => string.Format("{0}/{1}", Mathf.Clamp(CurrentHealth, 0, MaxHealth).ToString(), MaxHealth.ToString());
  }
}