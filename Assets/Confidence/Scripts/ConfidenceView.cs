using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ConfidenceView : MonoBehaviour
{
    protected int MaxValue => ConfidenceController.MaxConfidence;

    private void OnEnable()
    {
        ConfidenceController.ConfidenceChanged += OnConfidenceChanged;
    }
    
    private void OnDisable()
    {
        ConfidenceController.ConfidenceChanged -= OnConfidenceChanged;
    }

    private void Start()
    {
        InitializeView();
        SetValue(ConfidenceController.Confidence);
    }

    public abstract void SetValue(int value);

    protected abstract void InitializeView();

    private void OnConfidenceChanged(int newValue)
    {
        SetValue(newValue);
    }
}
