using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainLevel : MonoBehaviour
{
    private PauseMenu pauseMenu;
    private void Start() {
        pauseMenu = GameObject.Find("Pause Canvas").GetComponent<PauseMenu>();
    }
    private void Update() {

        if (Input.GetKeyDown(KeyCode.Q) && !pauseMenu.pauseMenu.activeSelf)
        {
            SceneManager.LoadScene(1);
        }
    }
}
