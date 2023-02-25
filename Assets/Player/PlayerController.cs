using Assets.InteractableObjects;
using System.Collections;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    public Animator animator;

    public Movement Movement;

    public PlayerInteractionController PlayerInteractionController;

    public ConfidenceController ConfidenceController;

    public TextBoxSpawner PlayerDialogBox;

    public TextBoxSpawner PlayerInteractBox;

    public PlayerTalkingController PlayerTalkingController;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    public void SetPlayerInput(bool isEnable)
    {
        if(Instance == null)
        {
            return;
        }

        Instance.Movement.enabled = isEnable;
        Instance.PlayerInteractionController.enabled = isEnable;
    }

    public void SetAnimationParam_Bool(string name, bool value)
    {
        if(Instance != null)
        {
            Instance.animator.SetBool(name, value);
        }
    }
}
