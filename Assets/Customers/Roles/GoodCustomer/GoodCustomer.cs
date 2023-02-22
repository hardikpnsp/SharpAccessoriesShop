using Assets.LevelMapObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodCustomer : Customer
{
    [SerializeField] PatienceController _patienceController;
    [SerializeField, Min(MinQueueWaitingTime)] private float _queueWaitingTime;

    private const float MinQueueWaitingTime = 0.1f;

    public event Action Served;
    public event Action WaitingTimeExpired;

    public bool CanJoinQueue => QueueController.CanJoinQueue();

    public Transform GetQueuePosition()
    {
        return QueueController.GetStartPosition();
    }

    public void JoinQueue()
    {
        Join();
        _patienceController.StartTimer(_queueWaitingTime);
    }

    public Transform ChooseStand()
    {
        WeaponStand stand = LevelMapController.GetRandomWeaponStand();

        if (stand == null)
            return null;

        bool positionFound = stand.TryTakeRandomPosition(out Transform position);
        return positionFound ? position : null;
    }

    private void OnWaitingTimeEnded()
    {
        Exit();
        WaitingTimeExpired?.Invoke();
    }

    private void OnServed(Customer customer)
    {
        if (customer != this)
            return;

        _patienceController.StopTimer();
        Exit();
        Served?.Invoke();
    }

    private void Join()
    {
        QueueController.JoinQueue(this);
        QueueController.Instance.CustomerServed.AddListener(OnServed);
        _patienceController.PatienceTimerEnded.AddListener(OnWaitingTimeEnded);
    }

    private void Exit()
    {
        QueueController.ExitQueue(this);
        QueueController.Instance.CustomerServed.RemoveListener(OnServed);
        _patienceController.PatienceTimerEnded.RemoveListener(OnWaitingTimeEnded);
    }
}
