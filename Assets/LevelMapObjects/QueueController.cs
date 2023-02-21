using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QueueController : MonoBehaviour
{
    [SerializeField]
    private TimerController TimerController;

    private List<Customer> customers = new List<Customer>();

    public CustomerServedEvent CustomerServed;

    [SerializeField]
    private Transform startPos;

    public Transform GetStartPosition()
    {
        return startPos;
    }

    public bool CanJoinQueue()
    {
        return true;
    }

    public void JoinQueue(Customer customer)
    {
        customers.Add(customer);
        TimerController.CreateTimer(5f, Service_Temp);
        
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

    public void ExitQueue(Customer customer)
    {
        customers.Remove(customer);
    }


    [System.Serializable]
    public class CustomerServedEvent : UnityEvent<Customer>
    { }
}
