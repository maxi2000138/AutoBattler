using System.Text;
using UnityEngine;

namespace Scenes.App.Scripts.Gameplay.Battle
{

  public class DamageLogger : IDamageLogger
  {
    private StringBuilder _logBuilder = new StringBuilder();
    
    public void StartBuildingLog(int characterStrength, int weaponDamage)
    {
      _logBuilder.Clear();
      _logBuilder.Append($"Unit strength: {characterStrength} + Weapon damage: {weaponDamage} = {characterStrength + weaponDamage}\n");
      AddSeparator();
    }
    
    public void AddAttackEffect(string effectString)
    {
      _logBuilder.AppendLine(effectString);
    }

    public void AddDefenceEffect(string effectString)
    {
      _logBuilder.AppendLine(effectString);
    }
    
    public void EndedAttackEffects()
    {
      AddSeparator();
    }
    
    public void FinishBuildingLog()
    {
      Debug.Log(_logBuilder.ToString());
    }
    
    private StringBuilder AddSeparator() => _logBuilder.AppendLine("--------------------------------");
  }
}