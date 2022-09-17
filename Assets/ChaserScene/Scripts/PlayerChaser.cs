using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChaser : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float rotationSpeed = 720f;

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        float inputMagnitude = Mathf.Clamp01(movement.magnitude);
        movement.Normalize();

        transform.Translate(movement * speed * inputMagnitude * Time.deltaTime, Space.World);

        if(movement != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movement);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
       
    }
}
