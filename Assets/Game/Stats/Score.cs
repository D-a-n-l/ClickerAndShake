using System;

public class Score : Stat
{
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

        OnIncreased?.Invoke(_current);
    }
}