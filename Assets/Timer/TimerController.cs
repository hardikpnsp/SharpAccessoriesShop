using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimerController : MonoBehaviour
{
    public static TimerController Instance { get; private set; }

    [SerializeField]
    private Timer prefab;

    private List<Timer> timers = new List<Timer>();

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

    }

    public Timer CreateTimer(float time, UnityAction onTimerEnd)
    {
        Timer timer = GetFreeTimer();

        timer.SetUpAndStart(time, onTimerEnd);

        return timer;
    }

    public Timer CreateTimer(float time)
    {
        Timer timer = GetFreeTimer();
        timer.SetUpAndStart(time);

        return timer;
    }

    private Timer GetFreeTimer()
    {
        foreach(Timer timer in timers)
        {
            if (!timer.IsWorking)
            {
                return timer;
            }
        }

        Timer newTimer = Instantiate(prefab, this.gameObject.transform);
        timers.Add(newTimer);
        return newTimer;
    }


    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

}
