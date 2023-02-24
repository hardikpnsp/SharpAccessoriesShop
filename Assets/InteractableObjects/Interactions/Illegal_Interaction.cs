using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

public class Illegal_Interaction : Interaction
{
    [Min(0)]
    public int confidenceNeeded;

    [SerializeField]
    TextBoxSpawner dialogTextBoxSpawner;

    TextBoxSpawner interactTextBoxSpawner;

    TextBoxSpawner playerDialog;

    [SerializeField]
    private DialogController_SO playerDialogFail;

    [SerializeField]
    private DialogController_SO playerDialogSuccess;

    private void Start()
    {
        playerDialog = PlayerController.Instance.PlayerDialogBox;
        interactTextBoxSpawner = PlayerController.Instance.PlayerInteractBox;
    }

    protected override bool CanInteract()
    {
        return true;
    }

    protected override InteractionResult Interact()
    {
        if(ConfidenceController.Confidence < confidenceNeeded)
        {
            dialogTextBoxSpawner.SpawnAndGetTextBox().SetUp(null, playerDialogFail.GetRandom());
            return InteractionResult.Fail;
        }
        else
        {
            ConfidenceController.DecreaseConfidence((uint)confidenceNeeded);
            playerDialog.SpawnAndGetTextBox().SetUp(null, playerDialogSuccess.GetRandom());
            return InteractionResult.Success;
        }
    }

    protected override void OnPlayerEnterZone()
    {
        interactTextBoxSpawner.SpawnAndGetTextBox().SetUp();
    }

    protected override void OnPlayerExitZone()
    {
        interactTextBoxSpawner.RemoveTextBox();

    }
}
