using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.InteractableObjects
{
    public class PlayerInteractionController : MonoBehaviour
    {
        public static PlayerInteractionController Instance;

        public UnityEvent OnTryInteract;

        private void Awake()
        {
            if(Instance == null)
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
            if(Instance == this)
            {
                Instance = null;
            }
        }

        public void Update()
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                OnTryInteract.Invoke();
            }
        }


    }
}