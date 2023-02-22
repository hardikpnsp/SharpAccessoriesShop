using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PatienceController : MonoBehaviour
{
    public UnityEvent PatienceTimerStarted;

    public UnityEvent PatienceTimerEnded;

    private TimerController TimerController;

    private Timer timer;

    private void Start()
    {
        TimerController = TimerController.Instance;

        if(TimerController == null)
        {
            throw new System.Exception("Timer controller Instance not set");
        }
    }

    public void StartTimer(float lengthSeconds)
    {
        timer = TimerController.CreateTimer(lengthSeconds, OnTimerEnd);

        PatienceTimerStarted.Invoke();
    }

    private void OnTimerEnd()
    {
        PatienceTimerEnded.Invoke();

        StopTimer();
    }

    public void StopTimer()
    {
        if(timer != null)
        {
            timer.StopAndReset();
            timer = null;
        }
    }
}
