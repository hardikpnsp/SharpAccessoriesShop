using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodCustomer : Customer
{
    [SerializeField, Min(MinQueueWaitingTime)] private float _queueWaitingTime;

    private const float MinQueueWaitingTime = 0.1f;

    private float _joiningQueueTime;
    private Coroutine _queueCoroutine;

    public event Action Served;
    public event Action WaitingTimeExpired;

    public bool CanJoinQueue {  get; private set; }

    public void JoinQueue()
    {
        _joiningQueueTime = Time.time;
        _queueCoroutine = StartCoroutine(WaitInQueue(_queueWaitingTime));
    }

    public Transform ChooseStall()
    {
        return transform;
    }

    public void BeServed()
    {
        if (_queueCoroutine == null)
            return;

        StopCoroutine(_queueCoroutine);
        Served?.Invoke();
    }

    private IEnumerator WaitInQueue(float waitingTime)
    {
        while (_joiningQueueTime + waitingTime > Time.time)
            yield return null;

        WaitingTimeExpired?.Invoke();
    }
}
