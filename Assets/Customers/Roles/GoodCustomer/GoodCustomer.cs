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

    [SerializeField] private SpriteOutliner SpriteOutliner;

    public Transform GetQueuePosition()
    {
        return QueueController.GetPosition(this);
    }

    public void JoinQueue()
    {
        Join();
        UpdateQueuePosition();
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
            //UpdateQueuePosition();
        }
        else
        {
            PatienceController.StopTimer();
            Exit();
            Served?.Invoke();
        }
    }

    private void Join()
    {
        QueueController.JoinQueue(this);
        QueueController.Instance.CustomerServed.AddListener(OnServed);
        QueueController.Instance.CustomerExit.AddListener(OnQueuePositionUpdated);
        PatienceController.PatienceTimerEnded.AddListener(OnWaitingTimeEnded);
        ReachedDestination += OnJoinedQueue;
    }

    private void Exit()
    {
        QueueController.Instance.CustomerServed.RemoveListener(OnServed);
        QueueController.Instance.CustomerExit.RemoveListener(OnQueuePositionUpdated);
        PatienceController.PatienceTimerEnded.RemoveListener(OnWaitingTimeEnded);
        QueueController.ExitQueue(this);
        SpriteOutliner.enabled = false;
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

    private void OnJoinedQueue()
    {
        PatienceController.StartTimer(_queueWaitingTime);
        ReachedDestination -= OnJoinedQueue;
        SpriteOutliner.enabled = true;
    }
}
