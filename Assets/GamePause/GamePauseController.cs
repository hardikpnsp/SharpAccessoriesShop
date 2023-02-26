using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauseController : MonoBehaviour
{
    public static GamePauseController instance;

    PlayerController PlayerController;

    [SerializeField]
    private GameObject pauseMenu;

    private bool isDefaultMenu;

    private bool isPaused;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void OnDestroy()
    {
        if(instance == this)
        {
            Time.timeScale = 1f;
            instance = null;
        }
    }

    private void Start()
    {
        pauseMenu.SetActive(false);
        PlayerController = PlayerController.Instance;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isPaused)
            {
                if (isDefaultMenu)
                {
                    Unpause();
                }
            }
            else
            {
                Pause();
            }
        }
    }

    public void PauseNoMenu()
    {
        if (isPaused)
        {
            Unpause();
        }

        isPaused = true;
        PlayerController.SetPlayerInput(false);
        isDefaultMenu = false;
        Time.timeScale = 0f;
    }

    public void Pause()
    {
        if (isPaused)
        {
            return;
        }

        pauseMenu.SetActive(true);
        isPaused = true;
        isDefaultMenu = true;
        PlayerController.SetPlayerInput(false);
        Time.timeScale = 0f;
    }

    public void Unpause()
    {
        if (!isPaused)
        {
            return;
        }

        pauseMenu.SetActive(false);
        isPaused = false;
        PlayerController.SetPlayerInput(true);
        Time.timeScale = 1f;
    }
}
