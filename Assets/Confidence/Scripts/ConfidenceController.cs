using System.Collections;
using UnityEngine;
using System;
using UnityEngine.Events;

public class ConfidenceController : MonoBehaviour
{
    [SerializeField] private uint _maxConfidence;
    [SerializeField] private uint _startConfidence;

    private static ConfidenceController instance;

    private Confidence _confidence;
    private static Confidence confidence => instance._confidence;

    public static int MaxConfidence => (int)instance._maxConfidence;
    public static int Confidence => confidence  == null ? 0 : confidence.Value;

    public static event UnityAction<int> ConfidenceChanged;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        _confidence = new Confidence(_maxConfidence, _startConfidence);
    }

    private void OnValidate()
    {
        if (_startConfidence > _maxConfidence)
            _startConfidence = _maxConfidence;
    }

    public static void IncreaseConfidence(uint value)
    {
        ChangeConfidence(confidence.IncreaseValue, (int)value);
    }

    public static void DecreaseConfidence(uint value)
    {
        ChangeConfidence(confidence.DecreaseValue, (int)value);
    }

    private static void ChangeConfidence(Action<int> action, int value)
    {
        if (value == 0)
            return;

        action.Invoke(value);
        ConfidenceChanged?.Invoke(confidence.Value);
    }
}
