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
    private readonly IDamageLogger _damageLogger;
    
    public DamageCalculator(WeaponsConfig weaponsConfig, UnitsConfig unitsConfig, IDamageLogger damageLogger)
    {
      _weaponsConfig = weaponsConfig;
      _unitsConfig = unitsConfig;
      _damageLogger = damageLogger;
    }
    
    public bool HitProbabilityOccurs(IUnit attacker, IUnit defender)
    {
      int probability = Random.Range(1, attacker.Stats.GetStat(StatType.Agility) + defender.Stats.GetStat(StatType.Agility) + 1);

      return probability > defender.Stats.GetStat(StatType.Agility);
    }
    
    public int CalculateDamage(IUnit attacker, IUnit defender, int turnNumber)
    {
      var environment = GetBaseEnviroment(attacker);
      environment.TurnNumber = turnNumber;
      
      foreach (Effect effect in attacker.EffectsContainer.AttackEffects)
      {
        if (effect.CanApply(attacker, defender, environment))
        { 
          _damageLogger.AddAttackEffect(effect.ToString(attacker, defender, environment));
          effect.Apply(attacker, defender, environment);
        }
      }
      
      _damageLogger.EndedAttackEffects();

      foreach (Effect effect in defender.EffectsContainer.DefenceEffects)
      {
        if (effect.CanApply(attacker, defender, environment))
        {
          _damageLogger.AddDefenceEffect(effect.ToString(attacker, defender, environment));
          effect.Apply(attacker, defender, environment);
        }
      }
        
      _damageLogger.FinishBuildingLog();
      return environment.Damage;
    }
    
    private EffectEnvironment GetBaseEnviroment(IUnit attacker)
    {
      int strength;
      int weaponDamage;

      if (attacker is Player player)
      {
        strength = player.Stats.GetStat(StatType.Strength);
        weaponDamage = _weaponsConfig.Weapons[player.WeaponType].Damage;
      }
      else if (attacker is Enemy enemy)
      {
        strength = enemy.Stats.GetStat(StatType.Strength);
        weaponDamage = _unitsConfig.Enemies[enemy.UnitType].WeaponDamage;
      }
      else
      {
        throw new Exception("Unknown unit type");
      }

      _damageLogger.StartBuildingLog(attacker is Player ? "Player" : "Enemy", strength, weaponDamage);

      return new EffectEnvironment(
        strength: strength, 
        weaponDamage: weaponDamage, 
        weapon: attacker is Player attackPlayer ? _weaponsConfig.Weapons[attackPlayer.WeaponType] : null);
    }
  }
}