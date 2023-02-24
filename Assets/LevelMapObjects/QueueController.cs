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

    public bool isReadyToServe = false;

    public CustomerServedEvent CustomerServed;
    public CustomerExitEvent CustomerExit;

    [SerializeField]
    private Transform startPos;

    [SerializeField]
    private Transform[] queuePositions;

    [SerializeField]
    private BuyingItemsInteraction interactable;

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

        if (interactable != null)
        {
            interactable.InteractionComplete.AddListener(OnPlayerInteract);
        }
    }

    public static Transform GetPosition(Customer customer)
    {
        if (Instance != null && customer != null)
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
        return Instance != null ? Instance.customers.Count < Instance.queuePositions.Length : false;
    }

    public static void JoinQueue(Customer customer)
    {
        if (Instance == null)
        {
            throw new System.Exception("QueueController Instance is null");
        }

        Instance.customers.Add(customer);

        if(Instance.customers.Count == 1)
        {
            customer.ReachedDestination += Instance.Customer_ReachedDestination;
            Instance.isReadyToServe = false;
        }
    }

    private void Customer_ReachedDestination()
    {
        isReadyToServe = true;
        
    }

    public static void ExitQueue(Customer customer)
    {
        if (Instance == null)
        {
            throw new System.Exception("QueueController Instance is null");
        }

        if (Instance.customers.Contains(customer))
        {
            int index = Instance.customers.IndexOf(customer);

            if(index == 0)
            {
                customer.ReachedDestination -= Instance.Customer_ReachedDestination;

                if(Instance.customers.Count >= 2)
                {
                    Instance.customers[1].ReachedDestination += Instance.Customer_ReachedDestination;
                    Instance.isReadyToServe = false;
                }
            }

            
            
            Instance.customers.Remove(customer);

            Instance.MoveCustomers();
            Instance.CustomerExit.Invoke();
        }


        
    }

    private void MoveCustomers()
    {
        foreach(Customer customer in customers)
        {
            customer.MoveTowards(GetPosition(customer));
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void OnPlayerInteract(Interaction.InteractionResult result)
    {
        CustomerServed.Invoke(customers[0]);
    }

    [System.Serializable]
    public class CustomerServedEvent : UnityEvent<Customer> { }

    [System.Serializable]
    public class CustomerExitEvent : UnityEvent { }
}
