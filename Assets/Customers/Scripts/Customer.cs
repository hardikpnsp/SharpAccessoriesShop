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

    public event Action ReachedDestination;

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

    public void MoveTowards(Transform target)
    {
        _movement.Move(target);
        _movement.DestinationReached += OnDestinationReached;
    }

    public void Leave(bool happy)
    {
        MoveTowards(_spawnPoint);
    }

    public void Despawn()
    {
    }

    private void OnDestinationReached() 
    {
        _movement.DestinationReached -= OnDestinationReached;
        ReachedDestination?.Invoke();
    }
}
