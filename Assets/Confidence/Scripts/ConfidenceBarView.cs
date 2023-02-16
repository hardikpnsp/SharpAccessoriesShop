using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BarView))]
public class ConfidenceBarView : ConfidenceView
{
    private BarView _barView;

    private void Awake()
    {
        _barView = GetComponent<BarView>();
    }

    public override void SetValue(int value)
    {
        _barView.SetValue(value);
    }

    protected override void InitializeView()
    {
        _barView.SetRange(0, MaxValue);
    }
}
