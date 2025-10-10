using System.Text;
using App.Scripts.Gameplay.Windows;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Scenes.App.Scripts.Gameplay.Battle
{

  public class DamageLogger : IDamageLogger
  {
    private const int LogDuration = 1500;
    
    private readonly IWindowRouter _windowRouter;
    private readonly StringBuilder _logBuilder = new StringBuilder();
    
    public DamageLogger(IWindowRouter windowRouter)
    {
      _windowRouter = windowRouter;
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
      UpdateLogText(_logBuilder.ToString());
      await UniTask.Delay(LogDuration);
      ClearLogs();
    }
    
    public void ClearLogs() => UpdateLogText("");
    
    private void UpdateLogText(string text) => _windowRouter.MainWindow.UpdateMainInfo(text);
    private void AddSeparator() => _logBuilder.AppendLine("--------------------------------");
  }
}