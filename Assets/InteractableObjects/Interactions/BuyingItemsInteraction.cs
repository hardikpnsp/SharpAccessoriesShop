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

    protected override bool CanInteract()
    {
        return true;
    }

    protected override void OnPlayerEnterZone()
    {
        interactTextBoxSpawner.SpawnTextBox();
    }

    protected override void OnPlayerExitZone()
    {
        interactTextBoxSpawner.RemoveTextBox();
    }

    protected override InteractionResult Interact()
    {
        playerDialog.SpawnAndGetTextBox().SetUp(null, playerDialogSuccess.GetRandom());
        confidenceController.IncreaseConfidence((uint)confidenceIncreace);
        return InteractionResult.Success;
    }
}

