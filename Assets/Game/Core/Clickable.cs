using UnityEngine;
using UnityEngine.Events;
using Zenject;

[RequireComponent(typeof(Collider2D))]
public class Clickable : MonoBehaviour
{
    [field: Min(1)]
    [field: SerializeField]
    public int BaseClick { get; private set; } = 1;

    private Energy _energy;

    public UnityEvent<int> OnDowned;

    [Inject]
    public void Construct(Energy energy)
    {
        _energy = energy;
    }

    public void OnMouseDown()
    {
        if (_energy.Current == 0)
            return;

        OnDowned?.Invoke(BaseClick);
    }
}