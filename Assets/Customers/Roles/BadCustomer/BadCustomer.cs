using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Illegal_Interaction))]
public class BadCustomer : Customer
{
    [SerializeField] private Illegal_Interaction _interaction;
    [SerializeField, Min(1)] private float _badActingTime;

    public event Action BadActingSucceded;
    public event Action BadActingPrevented;

    public void ActBadly()
    {
        StartActingBadly();
        PlayAnimation("ActBad");
    }

    private void OnTimerEnded()
    {
        StopActingBadly();
        BadActingSucceded?.Invoke();
    }

    private void OnInteracted(Interaction.InteractionResult result)
    {
        if (result == Interaction.InteractionResult.Success)
        {
            StopActingBadly();
            BadActingPrevented?.Invoke();
        }
    }

    private void StartActingBadly()
    {
        PatienceController.StartTimer(_badActingTime);
        PatienceController.PatienceTimerEnded.AddListener(OnTimerEnded);
        _interaction.InteractionComplete.AddListener(OnInteracted);
    }

    private void StopActingBadly()
    {
        PatienceController.StopTimer();
        PatienceController.PatienceTimerEnded.RemoveListener(OnTimerEnded);
        _interaction.InteractionComplete.RemoveListener(OnInteracted);
    }
}

