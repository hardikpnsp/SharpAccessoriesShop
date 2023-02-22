using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.BehaviourTrees;
using System;
    
[RequireComponent(typeof(BehaviourTreeOwner))]
[RequireComponent(typeof(CustomerMovement))]
public class Customer : MonoBehaviour
{
    private BehaviourTreeOwner _btOwner;
    private CustomerMovement _movement;
    private Transform _spawnPoint;
    private Transform _destination;

    public event Action ReachedDestination;
    public event Action<Customer, bool> Left;

    private void Awake()
    {
        _btOwner = GetComponent<BehaviourTreeOwner>();
        _movement = GetComponent<CustomerMovement>();
        _btOwner.StopBehaviour();
    }

    public void Spawn(Transform position)
    {
        _spawnPoint = position;
        transform.position = _spawnPoint.position;
        _btOwner.StartBehaviour();
    }

    public void MoveTowards(Transform destination)
    {
        _destination = destination;
        _movement.Move(destination);
        _movement.DestinationReached += OnDestinationReached;
    }

    public void Leave(bool happy)
    {
        Left?.Invoke(this, happy);
        MoveTowards(_spawnPoint);
    }

    public void Despawn()
    {
        Destroy(gameObject);
    }

    private void OnDestinationReached() 
    {
        _movement.DestinationReached -= OnDestinationReached;

        if (_destination == _spawnPoint)
            Despawn();

        ReachedDestination?.Invoke();
    }
}
