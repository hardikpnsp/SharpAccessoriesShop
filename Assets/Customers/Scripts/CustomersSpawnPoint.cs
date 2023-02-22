using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class CustomersSpawnPoint : MonoBehaviour
{
    [SerializeField, Min(MinSpawnDelay)] private float _spawnDelay;
    [SerializeField, Min(1)] private int _customersCount;
    [SerializeField] private CustomersDistribution _customerRolesDistribution;

    private const float MinSpawnDelay = 1f;

    public event Action<Customer> SpawnedCustomer;

    private void Start()
    {
        StartCoroutine(SpawnCustomers(_spawnDelay, _customersCount));
    }

    private IEnumerator SpawnCustomers(float delay, int customersCount)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(delay);
        Stack<Customer> customerStack = _customerRolesDistribution.GenerateDistribution(customersCount);

        while (customerStack.Count > 0)
        {
            SpawnCustomer(customerStack.Pop());
            yield return waitForSeconds;
        }
    }
    
    private Customer SpawnCustomer(Customer customerPrefab)
    {
        if (customerPrefab == null)
            throw new NullReferenceException("You must set reference to a Customer prefab.");

        Customer customer = Instantiate(customerPrefab, transform);
        customer.Spawn(transform);
        SpawnedCustomer?.Invoke(customer);
        return customer;
    }
}