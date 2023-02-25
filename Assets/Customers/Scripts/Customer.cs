using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.BehaviourTrees;
using System;
using Assets.LevelMapObjects;

[RequireComponent(typeof(BehaviourTreeOwner), typeof(CustomerMovement), typeof(Animator))]
public class Customer : MonoBehaviour
{
    [SerializeField] PatienceController _patienceController;

    private Animator _animator;
    private BehaviourTreeOwner _btOwner;
    private CustomerMovement _movement;
    private Transform _spawnPoint;
    private Transform _destination;
    private WeaponStand _stand;

    protected PatienceController PatienceController => _patienceController;

    public event Action ReachedDestination;
    public event Action<Customer, bool> Left;

    private void Awake()
    {
        _btOwner = GetComponent<BehaviourTreeOwner>();
        _movement = GetComponent<CustomerMovement>();
        _animator = GetComponent<Animator>();
        _btOwner.StopBehaviour();
    }

    public Transform ChooseStand()
    {
        _stand = LevelMapController.GetRandomWeaponStand();

        if (_stand == null)
            return null;

        bool positionFound = _stand.TryTakeRandomPosition(out Transform position);
        return positionFound ? position : null;
    }

    public void ReturnPosition(Transform position)
    {
        _stand.ReturnPosition(position);
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

    protected void PlayAnimation(string name)
    {
        _animator.Play(name);
    }

    protected void SetAnimationBool(string name, bool value)
    {
        _animator.SetBool(name, value);
    }

    private void OnDestinationReached() 
    {
        _movement.DestinationReached -= OnDestinationReached;

        if (_destination == _spawnPoint)
            Despawn();

        ReachedDestination?.Invoke();
    }
}
