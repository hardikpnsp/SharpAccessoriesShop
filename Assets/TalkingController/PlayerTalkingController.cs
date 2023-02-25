using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTalkingController : MonoBehaviour
{
    public float talkingLenghtSeconds;

    private PlayerController playerController;

    private const string TalkingAnimName = "Talking";

    private TimerController TimerController;

    private void Start()
    {
        playerController = PlayerController.Instance;
        TimerController = TimerController.Instance;

        if(playerController == null)
        {
            throw new System.Exception("PlayerController is null");
        }        
        
        if(TimerController == null)
        {
            throw new System.Exception("TimerController is null");
        }
    }

    public void Talk()
    {
        playerController.animator.SetBool(TalkingAnimName, true);
        playerController.SetPlayerInput(false);

        TimerController.CreateTimer(talkingLenghtSeconds, EndTalk);
    }

    private void EndTalk()
    {
        playerController.animator.SetBool(TalkingAnimName, false);
        playerController.SetPlayerInput(true);
    }
}
