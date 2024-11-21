using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class EnergyView : MonoBehaviour
{
    [SerializeField]
    private Slider _slider;

    private Energy _energy;

    [Inject]
    public void Construct(Energy energy)
    {
        _energy = energy;
    }

    private void Start()
    {
        _slider.maxValue = _energy.Max;

        _slider.value = _energy.Current;
    }

    public void Refresh(int value)
    {
        _slider.value = value;
    }
}