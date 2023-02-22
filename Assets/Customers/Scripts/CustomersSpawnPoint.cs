using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class CustomersSpawnPoint : MonoBehaviour
{
    [SerializeField, Min(MinSpawnDelay)] private float _spawnDelay;
    [SerializeField, Min(1)] private int _customersCount;
    [SerializeField] private CustomerRolesDistribution _customerRolesDistribution;
    [SerializeField] private QueueController _queueController;

    private const float MinSpawnDelay = 1f;

    private void Start()
    {
        StartCoroutine(SpawnCustomers(_spawnDelay, _customersCount));
    }

    private IEnumerator SpawnCustomers(float delay, int customersCount)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(delay);
        Stack<CustomerRole> customerStack = _customerRolesDistribution.GenerateDistribution(customersCount);

        while (customerStack.Count > 0)
        {
            SpawnCustomer(customerStack.Pop());
            yield return waitForSeconds;
        }
    }
    
    private Customer SpawnCustomer(CustomerRole customerRole)
    {
        if (customerRole == null)
            throw new NullReferenceException("You must set a reference to a CustomerRole instance.");

        Customer customer = Instantiate(customerRole.Prefab, transform);
        customer.Spawn(transform);
        return customer;
    }
}