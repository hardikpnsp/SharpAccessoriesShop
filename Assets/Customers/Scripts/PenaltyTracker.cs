using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenaltyTracker : MonoBehaviour
{
    [SerializeField] private CustomersSpawnPoint _customerSpawnPoint;

    private void OnEnable()
    {
        _customerSpawnPoint.SpawnedCustomer += OnCustomerSpawned;
    }

    private void OnDisable()
    {
        _customerSpawnPoint.SpawnedCustomer -= OnCustomerSpawned;
    }

    private void OnCustomerSpawned(Customer customer)
    {
        customer.Left += OnCustomerLeft;
    }

    private void OnCustomerLeft(Customer customer, bool happy)
    {
        customer.Left -= OnCustomerLeft;
    }
}
