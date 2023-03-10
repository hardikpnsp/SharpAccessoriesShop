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
    TextBoxSpawner playerDialog;

    [SerializeField]
    TextBoxSpawner interactTextBoxSpawner;

    QueueController QueueController;

    //TimerController TimerController;

    //bool inCooldown = false;

    //[SerializeField]
    //float cooldownTime;

    private void Start()
    {
        QueueController = QueueController.Instance;
        //TimerController = TimerController.Instance;
    }

    protected override bool CanInteract()
    {
        return !QueueController.Empty && QueueController.isReadyToServe;
    }

    protected override void OnPlayerEnterZone()
    {
        if(!QueueController.Empty)
            interactTextBoxSpawner.SpawnTextBox();
    }

    protected override void OnPlayerExitZone()
    {
            interactTextBoxSpawner.RemoveTextBox();
    }

    protected override InteractionResult Interact()
    {
        if(ConfidenceController.Confidence == 0)
        {
            GameMessageController.ShowMessage_NotEnoughConfidence();
            return InteractionResult.Fail;
        }

        playerDialog.SpawnAndGetTextBox().SetUp(null, playerDialogSuccess.GetRandom());
        ConfidenceController.IncreaseConfidence((uint)confidenceIncreace);

        // TimerController.CreateTimer(cooldownTime, OnTimerEnd);
        //inCooldown = true;

        PlayerController.Instance.PlayerTalkingController.Talk();

        return InteractionResult.Success;
    }

}

