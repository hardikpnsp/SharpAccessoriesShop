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
        return QueueController.GetPosition(this);
    }

    public void JoinQueue()
    {
        Join();
        UpdateQueuePosition();
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
        {
            UpdateQueuePosition();
        }
        else
        {
            _patienceController.StopTimer();
            Exit();
            Served?.Invoke();
        }
    }

    private void Join()
    {
        QueueController.JoinQueue(this);
        QueueController.Instance.CustomerServed.AddListener(OnServed);
        QueueController.Instance.CustomerExit.AddListener(OnQueuePositionUpdated);
        _patienceController.PatienceTimerEnded.AddListener(OnWaitingTimeEnded);
    }

    private void Exit()
    {
        QueueController.Instance.CustomerServed.RemoveListener(OnServed);
        QueueController.Instance.CustomerExit.RemoveListener(OnQueuePositionUpdated);
        QueueController.ExitQueue(this);
        _patienceController.PatienceTimerEnded.RemoveListener(OnWaitingTimeEnded);
    }

    private void UpdateQueuePosition()
    {
        Transform position = QueueController.GetPosition(this);
        MoveTowards(position);
    }

    private void OnQueuePositionUpdated()
    {
        UpdateQueuePosition();
    }
}
