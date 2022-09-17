using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public int teleportToScene;
    public GameObject newSpawnLocation;
    public GameObject player;
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
        {
            SetNewSpawnLocation(newSpawnLocation);
            SceneManager.LoadScene(teleportToScene);
        }
    }

    private void SetNewSpawnLocation(GameObject spawnLocation) {
        //Debug.LogError("\nCurrent player position:");
        //Debug.LogError("Current X: " + PlayerPrefs.GetFloat("spawn-location-x"));
        //Debug.LogError("Current Y: " + PlayerPrefs.GetFloat("spawn-location-y"));
        //Debug.LogError("Current Z: " + PlayerPrefs.GetFloat("spawn-location-z"));

        PlayerPrefs.SetFloat("spawn-location-x", spawnLocation.transform.position.x);
        PlayerPrefs.SetFloat("spawn-location-y", spawnLocation.transform.position.y);
        PlayerPrefs.SetFloat("spawn-location-z", spawnLocation.transform.position.z);

        //Debug.LogError("\nSetting new player position:");
        //Debug.LogError("New X: " + PlayerPrefs.GetFloat("spawn-location-x"));
        //Debug.LogError("New Y: " + PlayerPrefs.GetFloat("spawn-location-y"));
        //Debug.LogError("New Z: " + PlayerPrefs.GetFloat("spawn-location-z"));
    }
}
