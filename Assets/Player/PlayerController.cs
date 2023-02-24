using Assets.InteractableObjects;
using System.Collections;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    public Movement Movement;

    public PlayerInteractionController PlayerInteractionController;

    public ConfidenceController ConfidenceController;

    public TextBoxSpawner PlayerDialogBox;

    public TextBoxSpawner PlayerInteractBox;

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
}
