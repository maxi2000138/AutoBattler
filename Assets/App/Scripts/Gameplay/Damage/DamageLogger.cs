using System.Text;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Scenes.App.Scripts.Gameplay.Battle
{

  public class DamageLogger : IDamageLogger
  {
    private readonly TMP_Text _logText;
    private StringBuilder _logBuilder = new StringBuilder();
    
    public DamageLogger(TMP_Text logText)
    {
      _logText = logText;
    }
    
    public void StartBuildingLog(string attacker, int characterStrength, int weaponDamage)
    {
      _logBuilder.Clear();
      _logBuilder.Append($"Attacker: {attacker}\n");
      _logBuilder.Append($"Unit strength: {characterStrength} + Weapon damage: {weaponDamage} = {characterStrength + weaponDamage}\n");
      AddSeparator();
    }
    
    public void AddAttackEffect(string effectString) => _logBuilder.AppendLine(effectString);
    public void AddDefenceEffect(string effectString) => _logBuilder.AppendLine(effectString);
    public void EndedAttackEffects() => AddSeparator();
    public async UniTaskVoid FinishBuildingLog()
    {
      _logText.text = _logBuilder.ToString();
      await UniTask.Delay(1000);
      Clear();
    }
    public void Clear() => _logText.text = "";

    private void AddSeparator() => _logBuilder.AppendLine("--------------------------------");
  }
}