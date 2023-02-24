using Assets.InteractableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interaction : MonoBehaviour
{
    public bool ConnectToSelfInteractableOnStart;

    public UnityEvent<InteractionResult> InteractionComplete;

    protected InteractableObject interactableObject;

    protected void Awake()
    {
        if (ConnectToSelfInteractableOnStart)
        {
            interactableObject = GetComponent<InteractableObject>();

            if (interactableObject != null)
            {
                SetInteractable(interactableObject);
            }
            else
            {
                throw new System.Exception("Interaction controller is not connected to InteractableObject");
            }
        }      
    }

    public void SetInteractable(InteractableObject interactable)
    {
        if(this.interactableObject != null)
        {
            interactableObject.PlayerEnterZone.RemoveListener(OnPlayerEnterZone);
            interactableObject.PlayerExitZone.RemoveListener(OnPlayerExitZone);
            OnPlayerExitZone();
            interactableObject.PlayerInteract.RemoveListener(TryInteract);
        }

        if (interactable != null)
        {
            interactableObject = interactable;
            interactable.PlayerEnterZone.AddListener(OnPlayerEnterZone);
            interactable.PlayerExitZone.AddListener(OnPlayerExitZone);
            interactable.PlayerInteract.AddListener(TryInteract);
        }
       
    }

    protected virtual void OnPlayerEnterZone()
    {

    }
    protected virtual void OnPlayerExitZone()
    {

    }

    protected virtual bool CanInteract() 
    {
        return false;
    }

    private void TryInteract()
    {
        if (CanInteract())
        {
            var result = Interact();
            InteractionComplete.Invoke(result);
        }
    }

    protected virtual InteractionResult Interact()
    {
        return InteractionResult.Fail;
    }

    public enum InteractionResult
    {
        Success, Fail
    }

    [System.Serializable]
    public class InteractionEvent: UnityEvent<InteractionResult>
    {

    }
}
