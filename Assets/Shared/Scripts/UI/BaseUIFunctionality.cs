using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseUIFunctionality : MonoBehaviour
{
    public Text controlsMenuText;
    public Text soundMenuText;
    private TextChanger textChanger = new TextChanger();
    public GameObject baseScreen; // the first screen of used UI

    public void QuitGame() {
        Debug.Log("Quit");
        PlayerPrefs.DeleteKey("spawn-location-x");
        PlayerPrefs.DeleteKey("spawn-location-y");
        PlayerPrefs.DeleteKey("spawn-location-z");
        Application.Quit();
    }

    public void LoadControlsMenu(GameObject controlsMenu) {
        controlsMenu.SetActive(true);
        baseScreen.SetActive(false);
        textChanger.SetControlsMenuText(controlsMenuText);
    }

    public void ToBaseScreen(GameObject screenToClose) {
        baseScreen.SetActive(true);
        screenToClose.SetActive(false);
    }

    public void LoadSoundMenu(GameObject soundMenu) {
        soundMenu.SetActive(true);
        baseScreen.SetActive(false);

        if (!PlayerPrefs.HasKey("audio-volume"))
        {
            soundMenuText.text = "Volume 100%";
        }

        else
        {
            float currentAudioLevel = PlayerPrefs.GetFloat("audio-volume") * 100;
            soundMenuText.text = "Volume " + Mathf.Round(currentAudioLevel) + "%";
        }
    }
}
