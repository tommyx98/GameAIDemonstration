using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : BaseUIFunctionality
{
    public static bool isPaused = false;
    public static bool isPlaying = true; 
    public GameObject pauseMenu;
    public GameObject controlsMenu;

    private void Awake() {
        if(GameObject.FindGameObjectsWithTag("Pause").Length < 2)
        {
            DontDestroyOnLoad(this);
        }
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                Resume();
            }

            else
            {
                Pause();
            }
        }
    }

    public void Resume() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        isPlaying = true;
    }

    public void Pause() {
        pauseMenu.SetActive(true);
        controlsMenu.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
        isPlaying = false;
    }

    public bool IsPaused() {
        return isPaused;
    }
}
