using UnityEngine;

namespace App.Scripts.Infrastructure.VFX
{
  public interface IVFxFactory
  {
    void CreateVFx(VFxType vfx, Vector3 position);
  }
}