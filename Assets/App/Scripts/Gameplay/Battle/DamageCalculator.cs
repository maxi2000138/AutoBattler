using System;
using App.Scripts.Gameplay.Effects;
using App.Scripts.Gameplay.Stats;
using App.Scripts.Gameplay.Weapons._Config;
using Scenes.App.Scripts.Gameplay.Units;
using Scenes.App.Scripts.Gameplay.Units.Config;
using Random = UnityEngine.Random;

namespace Scenes.App.Scripts.Gameplay.Battle
{
  public class DamageCalculator : IDamageCalculator
  {
    private readonly WeaponsConfig _weaponsConfig;
    private readonly UnitsConfig _unitsConfig;
    public DamageCalculator(WeaponsConfig weaponsConfig, UnitsConfig unitsConfig)
    {
      _weaponsConfig = weaponsConfig;
      _unitsConfig = unitsConfig;
    }
    
    public bool HitProbabilityOccurs(IUnit attacker, IUnit defender)
    {
      int probability = Random.Range(1, attacker.Stats.GetStat(StatType.Agility) + defender.Stats.GetStat(StatType.Agility));

      return probability > defender.Stats.GetStat(StatType.Agility);
    }
    
    public int CalculateDamage(IUnit attacker, IUnit defender)
    {
      var damage = GetBaseDamage(attacker);
      
      foreach (Effect effect in attacker.EffectsContainer.AttackEffects) 
        damage = effect.Apply(attacker, defender, damage);
      
      foreach (Effect effect in defender.EffectsContainer.DefenceEffects)
        damage = effect.Apply(attacker, defender, damage);
        
      return damage;
    }
    
    private int GetBaseDamage(IUnit attacker)
    {
      if(attacker is Player player) 
        return player.Stats.GetStat(StatType.Strength) + _weaponsConfig.Weapons[player.WeaponType].Damage;
      
      if(attacker is Enemy enemy)
        return enemy.Stats.GetStat(StatType.Strength) + _unitsConfig.Enemies[enemy.UnitType].WeaponDamage;
      
      throw new Exception("Unknown unit type");
    }
  }
}