using Assets.InteractableObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Illegal_Interaction))]
public class BadCustomer : Customer
{
    [SerializeField] private Illegal_Interaction _interaction;
    [SerializeField, Min(1)] private float _badActingTime;
    [SerializeField] private InteractableObject InteractableObject;

    [SerializeField] private SpriteOutliner SpriteOutliner;

    public event Action BadActingSucceded;
    public event Action BadActingPrevented;

    public void ActBadly()
    {
        StartActingBadly();
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
        SetAnimationBool("ActBad", true);
        PatienceController.StartTimer(_badActingTime);
        PatienceController.PatienceTimerEnded.AddListener(OnTimerEnded);
        _interaction.InteractionComplete.AddListener(OnInteracted);
        _interaction.enabled = true;
        _interaction.SetInteractable(InteractableObject);
        SpriteOutliner.enabled = true;
    }

    private void StopActingBadly()
    {
        SetAnimationBool("ActBad", false);
        PatienceController.StopTimer();
        PatienceController.PatienceTimerEnded.RemoveListener(OnTimerEnded);
        _interaction.InteractionComplete.RemoveListener(OnInteracted);
        _interaction.SetInteractable(null);
        SpriteOutliner.enabled = false;
    }
}

