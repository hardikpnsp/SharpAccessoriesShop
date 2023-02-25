using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PenaltyTracker : MonoBehaviour
{
    [SerializeField] private CustomersSpawnPoint _customerSpawnPoint;
    [SerializeField, Min(1)] private uint _maxStrikes;
    [SerializeField] private uint _confidencePenalty;

    public int Strikes { get; private set; }

    public event UnityAction GameOver;
    public event UnityAction PlayerFined;

    private void Start()
    {
        Strikes = 0;
    }

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

        if (happy == false)
        {
            Strikes++;
            PlayerFined?.Invoke();

            ConfidenceController.DecreaseConfidence(_confidencePenalty);

            if (Strikes == _maxStrikes)
                GameOver?.Invoke();
        }
    }
}
