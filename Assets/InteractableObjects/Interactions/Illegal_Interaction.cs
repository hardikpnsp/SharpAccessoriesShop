using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Illegal_Interaction : Interaction
{
    [Min(0)]
    public int confidenceNeeded;

    [SerializeField]
    private ConfidenceController ConfidenceController;

    [SerializeField]
    TextBoxSpawner dialogTextBoxSpawner;

    [SerializeField]
    TextBoxSpawner interactTextBoxSpawner;

    [SerializeField]
    TextBoxSpawner playerDialog;

    [SerializeField]
    private DialogController_SO playerDialogFail;

    [SerializeField]
    private DialogController_SO playerDialogSuccess;

    protected override bool CanInteract()
    {
        return true;
    }

    protected override InteractionResult Interact()
    {
        if(ConfidenceController.Confidence < confidenceNeeded)
        {
            playerDialog.SpawnAndGetTextBox().SetUp(null, playerDialogFail.GetRandom());
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
