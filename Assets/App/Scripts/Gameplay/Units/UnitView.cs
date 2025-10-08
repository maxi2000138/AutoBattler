using System.Collections.Generic;
using App.Scripts.Gameplay.Stats;
using App.Scripts.Gameplay.Units;
using App.Scripts.Utils;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scenes.App.Scripts.Gameplay.Units
{
  public class UnitView : SerializedMonoBehaviour
  {
    private const float BackRotation = 181f;
    private const float ForwardRotation = 0f;

    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _view;
    [field: SerializeField] public Dictionary<StatType, UnitBar> StatBars { get; private set; }
    [field: SerializeField] public UnitBar HealthBar { get; private set; }
    
    public void Attack()
    {
      _animator.Play(Animations.Attack);
    }
    
    public void RotateTo(Vector2 lookTo)
    {
      float rotationY = lookTo.x < 0f ? BackRotation : ForwardRotation;
      _view.eulerAngles = new Vector3(transform.eulerAngles.x, rotationY, transform.eulerAngles.z);
    }
  }
}