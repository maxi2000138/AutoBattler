using System.Collections.Generic;
using App.Scripts.Gameplay.Stats;
using App.Scripts.Gameplay.Units;
using App.Scripts.Gameplay.Weapons._Config;
using App.Scripts.Gameplay.Weapons.Data;
using App.Scripts.Infrastructure.VFX;
using App.Scripts.Utils;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.App.Scripts.Gameplay.Units
{
  public class UnitView : SerializedMonoBehaviour
  {
    private const float BackRotation = 181f;
    private const float ForwardRotation = 0f;

    [SerializeField] private Transform _view;
    [SerializeField] private Animator _animator;
    [SerializeField] private Image _weaponImage;
    [SerializeField] private TMP_Text _unitInfoText;
    
    [field: SerializeField] public Dictionary<StatType, UnitBar> StatBars { get; private set; }
    [field: SerializeField] public UnitBar HealthBar { get; private set; }

    
    private IVFxFactory _vfxFactory;
    private WeaponsConfig _weaponsConfig;

    private Vector2 FxPosition => _view.position + (_view.up * 2f) + (_view.right * 2f);


    public void Construct(IVFxFactory vfxFactory, WeaponsConfig weaponsConfig)
    {
      _weaponsConfig = weaponsConfig;
      _vfxFactory = vfxFactory;
    }

    public void Reset()
    {
      _weaponImage.transform.parent.gameObject.SetActive(false);
      _unitInfoText.transform.parent.gameObject.SetActive(false);
    }
    
    public void SetWeapon(WeaponType weaponType)
    {
      _weaponImage.transform.parent.gameObject.SetActive(true);
      _weaponImage.sprite = _weaponsConfig.Weapons[weaponType].Sprite;
    }
    
    public void UpdateUnitStats(Dictionary<UnitType, int> unitTypes)
    {
      if (unitTypes == null || unitTypes.Count == 0) return;
      
      _unitInfoText.transform.parent.gameObject.SetActive(true);
      _unitInfoText.text = UnitTypesText(unitTypes);
    }
    
    public void Attack()
    {
      _animator.Play(Animations.Attack);
      _vfxFactory.CreateVFx(VFxType.Hit, FxPosition);
    }

    public void MissAttack()
    {
      _animator.Play(Animations.Attack);
      _vfxFactory.CreateVFx(VFxType.Miss, FxPosition);
    }


    public void RotateTo(Vector2 lookTo)
    {
      float rotationY = lookTo.x < 0f ? BackRotation : ForwardRotation;
      _view.eulerAngles = new Vector3(transform.eulerAngles.x, rotationY, transform.eulerAngles.z);
    }
    
    private string UnitTypesText(Dictionary<UnitType, int> unitTypes)
    {
        string result = string.Empty;
        foreach (var unitType in unitTypes.Keys) result += $"{unitType}: lvl {unitTypes[unitType]}\n";
        return result;
    }
  }
}