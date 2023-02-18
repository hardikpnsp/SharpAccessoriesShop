using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Debug_TimerUseExample : MonoBehaviour
{
    Image image;

    Timer timer;

    [SerializeField]
    float seconds = 5;

    private void Start()
    {
        image = GetComponent<Image>();

        //timer = TimerController.Instance.CreateTimer(seconds);

        //timer = TimerController.Instance.CreateTimer(seconds, null);

        timer = TimerController.Instance.CreateTimer(seconds, () => Debug.Log("Timer Ended"));
    }



    private void Update()
    {
        image.fillAmount =  timer.secondsLeft/seconds;
    }
}
