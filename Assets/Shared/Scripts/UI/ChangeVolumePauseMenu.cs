using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeVolumePauseMenu : MonoBehaviour
{
    private SoundManager soundManager;
    [SerializeField]
    private Text soundMenuText;
    [SerializeField]
    private Slider volume;

    // Start is called before the first frame update
    void Start()
    {
        soundManager = GameObject.Find("Audio").GetComponent<SoundManager>();

        // updating sound manager values to use the ones for pause menu
        soundManager.soundMenuText = soundMenuText;
        soundManager.volume = volume;
        soundManager.LoadVolume();
    }

    public void ChangeVolume() {
        soundManager.ChangeVolume();
    }
}
