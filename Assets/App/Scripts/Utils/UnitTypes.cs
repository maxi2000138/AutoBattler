using System;
using System.Collections.Generic;
using System.Linq;
using Scenes.App.Scripts.Gameplay.Units;

namespace App.Scripts.Utils
{
  public static class UnitTypes
  {
    public static List<UnitType> Player = Enum.GetValues(typeof(UnitType))
      .Cast<UnitType>()
      .Where(value => (int)value >= 1 && (int)value <= 100)
      .ToList();
    
    public static List<UnitType> Enemy = Enum.GetValues(typeof(UnitType))
      .Cast<UnitType>()
      .Where(value => (int)value >= 101 && (int)value <= 200)
      .ToList();
  }
}