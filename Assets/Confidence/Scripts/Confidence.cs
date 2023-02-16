using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Confidence
{
    public const int MinValue = 0;

    private int _maxValue;
    private int _value;

    public int MaxValue
    {
        get { return _maxValue; }
        set { _maxValue = Math.Clamp(value, MinValue, value); }
    }

    public int Value
    {
        get { return _value; }
        set { _value = Math.Clamp(value, MinValue, MaxValue); }
    }

    public Confidence(uint maxValue) : this(maxValue, maxValue) { } 

    public Confidence(uint maxValue, uint value)
    {
        MaxValue = (int)maxValue;
        Value = (int)value;
    }

    public void IncreaseValue(int value)
    {
        if (value < 0)
            throw new ArgumentException();

        Value += value;
    }

    public void DecreaseValue(int value)
    {
        if (value < 0)
            throw new ArgumentException();

        Value -= value;
    }
}