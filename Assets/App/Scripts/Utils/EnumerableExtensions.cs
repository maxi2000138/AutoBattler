using System.Collections.Generic;
using System.Linq;
using Sirenix.Utilities;
using UnityEngine;

namespace App.Scripts.Utils
{
  public static class EnumerableExtensions
  {
    public static T PickRandom<T>(this IEnumerable<T> collection)
    {
      T[] enumerable = collection as T[] ?? collection.ToArray();

      if (enumerable.IsNullOrEmpty())
        return default;
      
      return enumerable[Random.Range(0, enumerable.Length)];
    }
  }
}