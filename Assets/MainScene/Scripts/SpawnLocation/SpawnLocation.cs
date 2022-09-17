using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnLocation : MonoBehaviour
{
    public GameObject player;
    public GameObject baseSpawnLocation;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("spawn-location-x"))
        {
            Debug.LogError("X not found");
            PlayerPrefs.SetFloat("spawn-location-x", baseSpawnLocation.transform.position.x);
        }

        if (!PlayerPrefs.HasKey("spawn-location-y"))
        {
            Debug.LogError("Y not found");
            PlayerPrefs.SetFloat("spawn-location-y", baseSpawnLocation.transform.position.y);
        }

        if (!PlayerPrefs.HasKey("spawn-location-z"))
        {
            Debug.LogError("Z not found");
            PlayerPrefs.SetFloat("spawn-location-z", baseSpawnLocation.transform.position.z);
        }

        LoadSpawnLocation();
    }

    private void LoadSpawnLocation() {
        float x = PlayerPrefs.GetFloat("spawn-location-x");
        float y = PlayerPrefs.GetFloat("spawn-location-y");
        float z = PlayerPrefs.GetFloat("spawn-location-z");

        player.transform.position = new Vector3(x, y, z);

        //Debug.LogError("\nSetting player to this position:" + "(" + PlayerPrefs.GetFloat("spawn-location-x") + ", " + PlayerPrefs.GetFloat("spawn-location-y") + ", " + PlayerPrefs.GetFloat("spawn-location-z") + ")");
    }
}
