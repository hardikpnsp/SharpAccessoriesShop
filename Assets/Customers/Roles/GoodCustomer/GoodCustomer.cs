using Assets.LevelMapObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodCustomer : Customer
{
    [SerializeField, Min(MinQueueWaitingTime)] private float _queueWaitingTime;

    private const float MinQueueWaitingTime = 0.1f;

    public event Action Served;
    public event Action WaitingTimeExpired;

    public bool CanJoinQueue => QueueController.CanJoinQueue();

    public void JoinQueue()
    {
        QueueController.JoinQueue(this);
        QueueController.Instance.CustomerServed.AddListener(OnServed);
    }

    public Transform ChooseStand()
    {
        WeaponStand stand = LevelMapController.GetRandomWeaponStand();
        bool standFound = stand.TryTakeRandomPosition(out Transform position);
        return standFound ? position : null;
    }

    private void OnServed(Customer customer)
    {
        if (customer != this)
            return;

        QueueController.Instance.CustomerServed.RemoveListener(OnServed);
        Served?.Invoke();
    }
}
