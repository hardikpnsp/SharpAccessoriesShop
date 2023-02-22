using System;
using System.Collections.Generic;
using UnityEngine;

public class BuyingItemsInteraction : Interaction
{
    [SerializeField]
    private DialogController_SO playerDialogSuccess;

    [SerializeField]
    int confidenceIncreace;

    [SerializeField]
    ConfidenceController confidenceController;

    [SerializeField]
    TextBoxSpawner playerDialog;

    [SerializeField]
    TextBoxSpawner interactTextBoxSpawner;

    QueueController QueueController;

    TimerController TimerController;

    bool inCooldown = false;

    [SerializeField]
    float cooldownTime;

    private void Start()
    {
        QueueController = QueueController.Instance;
        TimerController = TimerController.Instance;
    }

    protected override bool CanInteract()
    {
        return !QueueController.Empty && !inCooldown;
    }

    protected override void OnPlayerEnterZone()
    {
        if(!QueueController.Empty)
            interactTextBoxSpawner.SpawnTextBox();
    }

    protected override void OnPlayerExitZone()
    {
        if (!QueueController.Empty)
            interactTextBoxSpawner.RemoveTextBox();
    }

    protected override InteractionResult Interact()
    {
        playerDialog.SpawnAndGetTextBox().SetUp(null, playerDialogSuccess.GetRandom());
        confidenceController.IncreaseConfidence((uint)confidenceIncreace);

        TimerController.CreateTimer(cooldownTime, OnTimerEnd);
        inCooldown = true;

        return InteractionResult.Success;
    }

    private void OnTimerEnd()
    {
        inCooldown = false;
    }
}

