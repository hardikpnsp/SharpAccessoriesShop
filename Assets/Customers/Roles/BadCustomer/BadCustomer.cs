using Assets.InteractableObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

[RequireComponent(typeof(Illegal_Interaction))]
public class BadCustomer : Customer
{
    [SerializeField] private Illegal_Interaction _interaction;
    [SerializeField, Min(1)] private float _badActingTime;

    [SerializeField] private InteractableObject InteractableObject;

    public event Action BadActingSucceded;
    public event Action BadActingPrevented;

    public void ActBadly()
    {
        StartActingBadly();
        //PlayAnimation("ActBad");
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
    }

    private void StopActingBadly()
    {
        SetAnimationBool("ActBad", false);
        PatienceController.StopTimer();
        PatienceController.PatienceTimerEnded.RemoveListener(OnTimerEnded);
        _interaction.InteractionComplete.RemoveListener(OnInteracted);
        _interaction.SetInteractable(null);
    }
}

