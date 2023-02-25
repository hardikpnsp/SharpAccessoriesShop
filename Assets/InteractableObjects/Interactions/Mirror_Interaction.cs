using Assets.InteractableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractableObject))]
public class Mirror_Interaction : Interaction
{
    public int confidenceIncreace;

    private bool inCooldown;

    [SerializeField]
    TextBoxSpawner dialogTextBoxSpawner;

    [SerializeField]
    TextBoxSpawner interactTextBoxSpawner;

    [SerializeField]
    private DialogController_SO dialog;

    protected override bool CanInteract()
    {
        return !inCooldown;
    }

    protected override InteractionResult Interact()
    {
        if (inCooldown)
        {
            return InteractionResult.Fail;
        }

        StartCooldown();
        GiveConfindence();
        //inCooldown = true;

        ShowDialog();
        PlayerController.Instance.PlayerTalkingController.Talk();

        return InteractionResult.Success;

    }

    protected override void OnPlayerEnterZone()
    {
        interactTextBoxSpawner.SpawnAndGetTextBox().SetUp();
    }

    protected override void OnPlayerExitZone()
    {
        interactTextBoxSpawner.RemoveTextBox();

    }

    private void GiveConfindence()
    {
        ConfidenceController.IncreaseConfidence((uint)confidenceIncreace);
    }

    private void StartCooldown()
    {

    }

    private void ShowDialog()
    {
       dialogTextBoxSpawner.SpawnAndGetTextBox().SetUp(null, dialog.GetRandom());
    }
}
