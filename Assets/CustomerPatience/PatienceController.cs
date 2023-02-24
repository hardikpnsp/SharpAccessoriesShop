using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PatienceController : MonoBehaviour
{
    public UnityEvent PatienceTimerStarted;

    public UnityEvent PatienceTimerEnded;

    public UnityEvent PatienceTimerStoped;

    private TimerController TimerController;

    public Timer timer;

    public float lengthSeconds;

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
        this.lengthSeconds = lengthSeconds;

        timer = TimerController.CreateTimer(lengthSeconds, OnTimerEnd);

        PatienceTimerStarted.Invoke();
    }

    private void OnTimerEnd()
    {
        if(timer != null)
        {
            PatienceTimerEnded?.Invoke();
        }


    }

    public void StopTimer()
    {
        if(timer != null)
        {
            timer.StopAndReset();
            timer = null;

            PatienceTimerStoped?.Invoke();
        }
    }
}
