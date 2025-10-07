using App.Scripts.Utils;
using UnityEngine;

namespace Scenes.App.Scripts.Gameplay.Units
{
  public class UnitView : MonoBehaviour
  {
    private const float BackRotation = 181f;
    private const float ForwardRotation = 0f;

    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _view;

    public void Attack()
    {
      _animator.Play(Animations.Attack);
    }
    
    public void RotateTo(Vector2 lookTo)
    {
      float rotationY = lookTo.x < 0f ? BackRotation : ForwardRotation;
      transform.eulerAngles = new Vector3(transform.eulerAngles.x, rotationY, transform.eulerAngles.z);
    }
  }
}