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

        private void Start()
        {
            SubscribeToPlayerEvents();
        }



        private void SubscribeToPlayerEvents()
        {
            
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
            return gameObject.CompareTag("Player");
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (IsPlayer(collision.gameObject))
            {
                playerInRange = true;
                PlayerEnterZone.Invoke();
            }
            
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                playerInRange = false;
                PlayerExitZone.Invoke();
            }
               
        }
    }
}