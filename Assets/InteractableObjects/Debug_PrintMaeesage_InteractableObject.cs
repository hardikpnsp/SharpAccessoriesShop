using System.Collections;
using UnityEngine;

namespace Assets.InteractableObjects
{
    public class Debug_PrintMaeesage_InteractableObject : MonoBehaviour
    {
        public void Print_PlayerEnter()
        {
            Debug.Log("Player Enter Interact zone");
        }

        public void Print_PlayerExit()
        {
            Debug.Log("Player Exit Interact zone");
        }

        public void Print_Interact()
        {
            Debug.Log("Player Interact");
        }
    }
}