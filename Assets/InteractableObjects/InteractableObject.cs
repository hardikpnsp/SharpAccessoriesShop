using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.InteractableObjects
{
    public class InteractableObject : MonoBehaviour
    {
        public UnityEvent PlayerEnterZone;
        public UnityEvent PlayerExitZone;
        public UnityEvent PlayerInteract;

        private bool playerInRange;

        PlayerInteractionController interactionController;

        private void Start()
        {

            interactionController = PlayerInteractionController.Instance;

            if(interactionController == null)
            {
                Debug.LogError("Interaction controller is not set");
            }
        }


        private void OnPlayerInteract()
        {
            if (playerInRange)
            {
                PlayerInteract.Invoke();
            }
        }

        private bool IsPlayer(GameObject gameObject)
        {
            return interactionController.gameObject == gameObject;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (IsPlayer(collision.gameObject))
            {
                interactionController.OnTryInteract.AddListener(OnPlayerInteract);

                playerInRange = true;
                PlayerEnterZone.Invoke();
            }
            
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (IsPlayer(collision.gameObject))
            {
                interactionController.OnTryInteract.RemoveListener(OnPlayerInteract);
                playerInRange = false;
                PlayerExitZone.Invoke();
            }
               
        }
    }
}