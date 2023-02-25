using Assets.InteractableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractableObject))]
public class Mirror_Interaction : Interaction
{
    public int confidenceIncreace;

    [SerializeField]
    private float cooldownLength;

    private bool inCooldown;

    [SerializeField]
    TextBoxSpawner dialogTextBoxSpawner;

    [SerializeField]
    TextBoxSpawner interactTextBoxSpawner;

    [SerializeField]
    private DialogController_SO dialog;

    [SerializeField]
    PatienceController PatienceController;

    private void Start()
    {
        PatienceController.PatienceTimerEnded.AddListener(OnPatienceTimerEnded);
    }

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
        GiveConfindence();
        //inCooldown = true;

        ShowDialog();
        
        inCooldown = true;
        PatienceController.StartTimer(cooldownLength);
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

    private void OnPatienceTimerEnded()
    {
        inCooldown = false;
    }
    private void ShowDialog()
    {
       dialogTextBoxSpawner.SpawnAndGetTextBox().SetUp(null, dialog.GetRandom());
    }
}
