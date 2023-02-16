using System.Collections;
using UnityEngine;
using System;
using UnityEngine.Events;

public class ConfidenceController : MonoBehaviour
{
    [SerializeField] private uint _maxConfidence;
    [SerializeField] private uint _startConfidence;

    private Confidence _confidence;

    public int MaxConfidence => (int)_maxConfidence;
    public int Confidence => _confidence == null ? 0 : _confidence.Value;

    public event UnityAction<int> ConfidenceChanged;

    private void Awake()
    {
        _confidence = new Confidence(_maxConfidence, _startConfidence);
    }

    private void OnValidate()
    {
        if (_startConfidence > _maxConfidence)
            _startConfidence = _maxConfidence;
    }

    public void IncreaseConfidence(uint value)
    {
        ChangeConfidence(_confidence.IncreaseValue, (int)value);
    }

    public void DecreaseConfidence(uint value)
    {
        ChangeConfidence(_confidence.DecreaseValue, (int)value);
    }

    private void ChangeConfidence(Action<int> action, int value)
    {
        if (value == 0)
            return;

        if (_confidence == null)
            StartCoroutine(WaitForInitialization());

        action.Invoke(value);
        ConfidenceChanged?.Invoke(_confidence.Value);
    }

    private IEnumerator WaitForInitialization()
    {
        while (_confidence == null)
            yield return null;
    }
}
