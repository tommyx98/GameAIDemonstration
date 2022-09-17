using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollowingAgent : MonoBehaviour
{
    private Vector2 target;
    private List<Transform> points;
    private int index = 0;
    private int maxIndex;

    [Header("Path")]
    public Path path;
    public float minDistanceFromPoint = 6;

    [Header("Seek")]
    public float agentMass = 15;
    public float maxVelocity = 3;
    public float maxForce = 15;
    private Vector2 velocity;

    public Transform projectionPoint;

    private Vector2 dVelocity;

    private void Start() {
        points = path.allPoints;
        maxIndex = points.Count - 1;
        velocity = Vector2.zero;
    }
    private void Update() {
        GetTargetPoint();
        Seeker();
    }

    private void GetTargetPoint() {
        if(points.Count <= 0)
        {
            return;
        }

        if (index == maxIndex)
        {
            if (Vector3.Distance(transform.position, points[index].position) <= minDistanceFromPoint)
            {
                points.Reverse();
                index = 0;
            }
        }
        
        if(Vector3.Distance(transform.position, points[index].position) <= minDistanceFromPoint)
        {
            index++;
        }
        

        target = points[index].position;
    }

    private void Seeker() {
        Vector2 desiredVelocity = target - (Vector2)transform.position;
        desiredVelocity = desiredVelocity.normalized * maxVelocity;

        Vector2 steering = desiredVelocity - velocity;
        steering = Vector2.ClampMagnitude(steering, maxForce);
        steering /= agentMass;

        velocity = Vector2.ClampMagnitude(velocity + steering, maxVelocity);
        transform.position += (Vector3)velocity * Time.deltaTime;
        transform.up = velocity.normalized;

        Debug.DrawRay(transform.position, velocity.normalized * 2, Color.green);
    }
}
