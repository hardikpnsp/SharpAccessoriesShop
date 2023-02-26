using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    public GameObject tutorialWindow;

    public UnityEngine.UI.Button tutorialButton;

    private void Start()
    {
        TimerController.Instance.CreateTimer(1f, OnTimerEnd);
        tutorialButton.onClick.AddListener(OnClick);
    }

    private void OnTimerEnd()
    {
        tutorialWindow.SetActive(true);
        GamePauseController.instance.PauseNoMenu();
    }

    private void OnClick()
    {
        tutorialWindow.SetActive(false);
        GamePauseController.instance.Unpause();
    }
}
