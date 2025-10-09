using App.Scripts.Infrastructure.VFX._Config;
using UnityEngine;
namespace App.Scripts.Infrastructure.VFX
{
  public class VFxFactory : IVFxFactory
  {
    private readonly VFxConfig _vFxConfig;
    public VFxFactory(VFxConfig vFxConfig)
    {
      _vFxConfig = vFxConfig;
    }
    
    public void CreateVFx(VFxType vfx, Vector3 position)
    {
      var fx = Object.Instantiate(_vFxConfig.VFx[vfx], position, Quaternion.identity);
    }
  }
}