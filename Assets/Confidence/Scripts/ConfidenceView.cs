using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ConfidenceView : MonoBehaviour
{
    [SerializeField] private ConfidenceController _controller;

    protected int MaxValue => _controller.MaxConfidence;

    private void OnEnable()
    {
        _controller.ConfidenceChanged += OnConfidenceChanged;
    }

    private void OnDisable()
    {
        _controller.ConfidenceChanged -= OnConfidenceChanged;
    }

    private void Start()
    {
        InitializeView();
        SetValue(_controller.Confidence);
    }

    public abstract void SetValue(int value);

    protected abstract void InitializeView();

    private void OnConfidenceChanged(int newValue)
    {
        SetValue(newValue);
    }
}
