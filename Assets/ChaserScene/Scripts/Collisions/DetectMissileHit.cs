using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectMissileHit : MonoBehaviour
{
    public GameObject gameOverScreen;
    private void OnTriggerEnter2D(Collider2D collision) {
        
        if (collision.gameObject.tag == "Missile")
        {
            Time.timeScale = 0f;
            gameOverScreen.SetActive(true);
        }
    }
}
