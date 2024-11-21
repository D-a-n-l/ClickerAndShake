using System;
using UnityEngine;
using System.Collections;

public class Energy : Stat
{
    [Min(1)]
    [SerializeField]
    private int _amountRecovery;

    [Min(0.001f)]
    [SerializeField]
    private float _timeRecovery;

    private WaitForSeconds _timeRecoveryW;

    private void Start()
    {
        _timeRecoveryW = new WaitForSeconds(_timeRecovery);

        StartCoroutine(IncreaseCoroutine());
    }

    public override void Decrease(int value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value), "value must be positive.");

        _current -= value;

        if (_current < 0)
            _current = 0;

        OnDecreased?.Invoke(_current);
    }

    public override void Increase(int value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value), "value must be positive.");

        _current += value;

        if (_current > _max)
            _current = _max;

        OnIncreased?.Invoke(_current);
    }

    private IEnumerator IncreaseCoroutine()
    {
        yield return _timeRecoveryW;

        Increase(_amountRecovery);

        StartCoroutine(IncreaseCoroutine());
    }
}