using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepInScreen : MonoBehaviour
{
    private float left = Screen.width;
    private float right = Screen.width;
    private float bottom = Screen.height;
    private float top = Screen.height;
    public float buffer = 1.0f;
    private Camera cam;
    private float distanceZ = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        distanceZ = Mathf.Abs(cam.transform.position.z + transform.position.z);

        left = cam.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).x;
        right = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, distanceZ)).x;
        bottom = cam.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).y;
        top = cam.ScreenToWorldPoint(new Vector3(0.0f, Screen.height, distanceZ)).y;
    }

    void FixedUpdate()
    {
        if(transform.position.x < left - buffer)
        {
            transform.position = new Vector3(right + buffer, transform.position.y, transform.position.z);
        }

        if(transform.position.x > right + buffer)
        {
            transform.position = new Vector3(left - buffer, transform.position.y, transform.position.z);
        }

        if(transform.position.y < bottom - buffer)
        {
            transform.position = new Vector3(transform.position.x, top + buffer, transform.position.z);
        }

        if(transform.position.y > top + buffer)
        {
            transform.position = new Vector3(transform.position.x, bottom - buffer, transform.position.z);
        }
    }
}
