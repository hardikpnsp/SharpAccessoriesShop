using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QueueController : MonoBehaviour
{
    public static QueueController Instance { get; private set; }

    [SerializeField]
    private TimerController TimerController;

    [SerializeField]
    private List<Customer> customers = new List<Customer>();

    public CustomerServedEvent CustomerServed;

    [SerializeField]
    private bool Debug_ImmidiatlyServCustomer;

    [SerializeField]
    private Transform startPos;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public static Transform GetStartPosition()
    {
        if(Instance != null)
            return Instance.startPos;
        else
            return null;
    }

    public static bool CanJoinQueue()
    {
        if (Instance != null)
            return true;
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

        if(Instance.Debug_ImmidiatlyServCustomer)
        Instance.Service_Temp();
        
    }

    private void Service_Temp()
    {
        if(customers.Count > 0)
        {
            Customer customer = customers[0];
            customers.RemoveAt(0);

            if (customer != null)
            {
                CustomerServed.Invoke(customer);
            }
        }
       
        
    }

    public static void ExitQueue(Customer customer)
    {
        if (Instance == null)
        {
            throw new System.Exception("QueueController Instance is null");
        }

        Instance.customers.Remove(customer);
    }

    private void OnDestroy()
    {
        if(Instance == this)
        {
            Instance = null;
        }
    }

    [System.Serializable]
    public class CustomerServedEvent : UnityEvent<Customer>
    { }
}
