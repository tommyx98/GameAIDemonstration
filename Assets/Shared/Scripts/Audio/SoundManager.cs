using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Slider volume;
    public Text soundMenuText;

    private void Awake() {
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("audio-volume"))
        {
            PlayerPrefs.SetFloat("audio-volume", 1);
            LoadVolume();
        }

        else
        {
            LoadVolume();
        }
    }

    public void ChangeVolume() {
        AudioListener.volume = volume.value;
        SaveVolume();
        soundMenuText.text = "Volume " + Mathf.Round(PlayerPrefs.GetFloat("audio-volume") * 100) + "%";
    }

    public void LoadVolume() {
        volume.value = PlayerPrefs.GetFloat("audio-volume");
    }

    private void SaveVolume() {
        PlayerPrefs.SetFloat("audio-volume", volume.value);
    }
}
