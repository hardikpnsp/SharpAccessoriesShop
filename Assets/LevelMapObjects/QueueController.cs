using Assets.InteractableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BuyingItemsInteraction), typeof(InteractableObject))]
public class QueueController : MonoBehaviour
{
    public static QueueController Instance { get; private set; }

    [SerializeField]
    private TimerController TimerController;

    [SerializeField]
    private List<Customer> customers = new List<Customer>();

    public bool Empty
    {
        get
        {
            return this.customers.Count == 0;
        }
    }

    public CustomerServedEvent CustomerServed;

    [SerializeField]
    private Transform startPos;

    [SerializeField]
    private Transform[] queuePositions;

    [SerializeField]
    private BuyingItemsInteraction interactable;

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

        if(interactable != null)
        {
            interactable.InteractionComplete.AddListener(OnPlayerInteract);
        }
    }

    public static Transform GetPosition(Customer customer)
    {
        if(Instance != null && customer != null)
        {
            if (Instance.customers.Contains(customer))
            {
                int index = Instance.customers.IndexOf(customer);

                return Instance.queuePositions[index];
            }
            else
            {
                if (CanJoinQueue())
                {
                    return Instance.queuePositions[Instance.customers.Count + 1];
                }
            }
        }
        return null;

    }

    public static bool CanJoinQueue()
    {
        if (Instance != null)
        {
            return Instance.customers.Count < Instance.queuePositions.Length;
        }
        else
            return false;
    }

    public static void JoinQueue(Customer customer)
    {
        if(Instance == null)
        {
            throw new System.Exception("QueueController Instance is null");
        }

        Instance.customers.Add(customer);
        
    }

    public static void ExitQueue(Customer customer)
    {
        //if (Instance == null)
        //{
        //    throw new System.Exception("QueueController Instance is null");
        //}

        //Instance.customers.Remove(customer);
    }


    private void OnDestroy()
    {
        if(Instance == this)
        {
            Instance = null;
        }
    }

    private void OnPlayerInteract(Interaction.InteractionResult result)
    {
        customers.Remove(customers[0]);

        CustomerServed.Invoke(customers[0]);

    }

    [System.Serializable]
    public class CustomerServedEvent : UnityEvent<Customer>
    { }
}
