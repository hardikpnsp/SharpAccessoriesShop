using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    private float startValue;

    [HideInInspector]
    public float secondsLeft;

    private bool isWorking;

    public bool IsWorking
    {
        get { return isWorking; }
    }

    private UnityEvent timerEnded;

    private void Awake()
    {
        timerEnded = new UnityEvent();
    }

    private void Update()
    {
        if (isWorking)
        {
            secondsLeft -= Time.deltaTime;

            if(secondsLeft <= 0)
            {
                OnTimerEnd();
            }
        }
    }

    public void SetUpAndStart(float time, UnityAction onTimerEnd)
    {
        ResetTimer();

        startValue = time;
        secondsLeft = time;

        if(onTimerEnd != null)
        timerEnded.AddListener(onTimerEnd);

        isWorking = true;
    }

    public void SetUpAndStart(float time)
    {
        startValue = time;
        secondsLeft = time;
        isWorking = true;
    }

    public void StopAndReset()
    {
        isWorking = false;

        ResetTimer();
    }

    private void ResetTimer()
    {
        timerEnded.RemoveAllListeners();
        secondsLeft = 0;
        startValue = 0;
    }

    private void OnTimerEnd()
    {
        isWorking = false;

        timerEnded?.Invoke();

        ResetTimer();

    }
}
