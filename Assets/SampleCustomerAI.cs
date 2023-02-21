using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is just a sample script that demonstrates how to move the Customer using CustomerMovement Script
public class SampleCustomerAI : MonoBehaviour
{
    // Goal can be attached in Unity Inspector
    // (Any gameObject with a Transform component will do
    // Actual AI will have list of all the goal transforms
    public Transform goal;
    private CustomerMovement customerMovement;

    void Start()
    {
        customerMovement = GetComponent<CustomerMovement>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            customerMovement.Move(goal);
        }
    }

    public void ReachedDebugCallback()
    {
        Debug.Log("REACHED DESTINATION");
    }
}
