using Cysharp.Threading.Tasks;

namespace Scenes.App.Scripts.Gameplay.Battle
{
  public interface IDamageLogger
  {
    void StartBuildingLog(string attacker, int characterStrength, int weaponDamage);
    void AddAttackEffect(string effectString);
    void AddDefenceEffect(string effectString);
    void EndedAttackEffects();
    UniTaskVoid FinishBuildingLog();
    void ClearLogs();
  }
}