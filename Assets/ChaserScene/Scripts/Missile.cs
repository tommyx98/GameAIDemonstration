using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public GameObject target;
    public float speed = 8;
    public PauseMenu pauseMenu;

    private void Start() {
        pauseMenu = GameObject.Find("Pause Canvas").GetComponent<PauseMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move() {

        if (pauseMenu.pauseMenu.activeSelf)
        {
            return;
        }

        Vector3 dir = transform.position - target.transform.position;
        dir = dir.normalized;
        transform.position -= dir * Time.deltaTime * speed;

        // rotate towards moving direction
        Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, dir);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 720 * Time.deltaTime);
    }
}
