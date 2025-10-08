using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.Gameplay.Units
{
  public class UnitBar : MonoBehaviour
  {
    [SerializeField] private Image _fill;
    [SerializeField] private TextMeshProUGUI _text;

    public Image Fill => _fill;
    public TextMeshProUGUI Text => _text;
  }
}