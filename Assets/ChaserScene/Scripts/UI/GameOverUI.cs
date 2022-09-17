using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public void QuitButton() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void RetryButton() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(3);
    }
}
