using UnityEngine;

namespace App.Scripts.Utils
{
  public static class Mathematics
  {
    public static float Remap(float inputMin, float inputMax, float outputMin, float outputMax, float value)
    {
      return Mathf.Lerp(outputMin, outputMax, Mathf.InverseLerp(inputMin, inputMax, value));
    }
  }
}