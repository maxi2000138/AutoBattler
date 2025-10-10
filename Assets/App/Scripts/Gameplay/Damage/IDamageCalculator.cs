using Scenes.App.Scripts.Gameplay.Units;

namespace Scenes.App.Scripts.Gameplay.Battle
{
  public interface IDamageCalculator
  {
    int CalculateDamage(IUnit attacker, IUnit defender);
    bool HitProbabilityOccurs(IUnit attacker, IUnit defender);
  }
}