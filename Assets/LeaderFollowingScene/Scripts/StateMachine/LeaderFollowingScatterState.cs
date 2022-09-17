using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderFollowingScatterState : LeaderFollowingBaseState
{
    private float chanceToTurn = 0.025f;
    private float maximumRadius = 5f;

    private float mass = 8f;
    private float maximumSpeed = 1f;
    private float maximumForce = 8f;

    private Vector2 velocity;
    private Vector3 forceForWander;
    private Vector3 target;

    private float min = 0.05f;
    private float max = 0.1f;

    public override void EnterState(LeaderFollowingStateManager manager) {
        manager.spriteRenderer.sprite = manager.notLeaderSprite;
        velocity = Random.onUnitSphere;
        forceForWander = GetRandomForce(manager);
    }

    public override void UpdateState(LeaderFollowingStateManager manager) {

        Vector2 desiredVelocity = GetForce(manager);
        desiredVelocity = desiredVelocity.normalized * maximumSpeed;

        Vector2 steeringForce = desiredVelocity - velocity;
        steeringForce = Vector2.ClampMagnitude(steeringForce, maximumForce);
        steeringForce /= mass;

        velocity = Vector2.ClampMagnitude(velocity + steeringForce, maximumSpeed);
        manager.transform.position += (Vector3)velocity * Time.deltaTime;
        manager.transform.up = velocity.normalized;

        Debug.DrawRay(manager.transform.position, velocity.normalized * 2, Color.green);
        Debug.DrawRay(manager.transform.position, desiredVelocity.normalized * 2, Color.magenta);
    }

    private Vector2 GetForce(LeaderFollowingStateManager manager) {
        if (manager.transform.position.magnitude > maximumRadius)
        {
            Vector2 directionToCenter = (target - manager.transform.position).normalized;
            forceForWander = velocity.normalized + directionToCenter;
        }

        else if (Random.value < chanceToTurn)
        {
            forceForWander = GetRandomForce(manager);
        }

        return forceForWander;
    }
    private Vector2 GetRandomForce(LeaderFollowingStateManager manager) {
        Vector2 centerOfCircle = velocity.normalized;
        Vector2 force = RandomPointInCircle(centerOfCircle);
        return force;
    }

    private Vector2 RandomPointInCircle(Vector2 origin) {
        Vector2 randomDirection = (Random.insideUnitCircle * origin).normalized;
        float randomDistance = Random.Range(min, max);
        return origin + randomDirection * randomDistance;
    }

}
