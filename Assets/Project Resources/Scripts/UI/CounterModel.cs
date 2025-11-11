using System;

public class CounterModel
{
    private int _count = 0;

    public event Action<int> ChangedCount;

    public void CalculateCount()
    {
        _count++;
        ChangedCount?.Invoke(_count);
    }
}
