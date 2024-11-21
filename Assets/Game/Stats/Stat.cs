using UnityEngine;
using UnityEngine.Events;

public abstract class Stat : MonoBehaviour
{
    [Min(1)]
    [SerializeField]
    protected int _max;

    public int Max => _max;

    protected int _current;

    public int Current => _current;

    public UnityEvent<int> OnDecreased;

    public UnityEvent<int> OnIncreased;

    private void Awake()
    {
        _current = _max;
    }

    public abstract void Decrease(int value);

    public abstract void Increase(int value);
}