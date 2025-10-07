namespace Scenes.App.Scripts.Gameplay.Units
{
  public class Unit : IUnit
  {
    public UnitView View { get; private set; }
    
    public void SetView(UnitView view)
    {
      View = view;
    }
  }
}