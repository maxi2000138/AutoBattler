namespace Scenes.App.Scripts.Gameplay.Battle
{
  public interface IDamageLogger
  {
    void StartBuildingLog(int characterStrength, int weaponDamage);
    void AddAttackEffect(string effectString);
    void AddDefenceEffect(string effectString);
    void EndedAttackEffects();
    void FinishBuildingLog();
  }
}