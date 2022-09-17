using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentWanderState : AgentBaseState
{
    private float radiusOfCircle = 1f;
    private float chanceToTurn = 0.05f;
    private float maximumRadius = 10;

    private float mass = 15;
    private float maximumSpeed = 3;
    private float maximumForce = 15;

    private Vector2 velocity;
    private Vector3 forceForWander;
    private Vector3 target;

    // put state specific behavior here, animation etc.
    public override void EnterState(AgentStateManager manager) {
        manager.spriteRenderer.sprite = manager.wanderSprite;
        velocity = Random.onUnitSphere;
        forceForWander = GetRandomForceForWander(manager);
    }

    public override void UpdateState(AgentStateManager manager) {

        if (manager.GetDistanceToFleeObject() <= manager.minFleeDistance)
        {
            manager.SwitchState(manager.fleeState);
        }

        // wander logic
        else
        {
            Vector2 desiredVelocity = GetForceForWander(manager);
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
    }

    private Vector2 GetForceForWander(AgentStateManager manager) {
        if(manager.transform.position.magnitude > maximumRadius)
        {
            Vector2 directionToCenter = (target - manager.transform.position).normalized;
            forceForWander = velocity.normalized + directionToCenter;
        }

        else if(Random.value < chanceToTurn)
        {
            forceForWander = GetRandomForceForWander(manager);
        }

        return forceForWander;
    }
    private Vector2 GetRandomForceForWander(AgentStateManager manager) {
        Vector3 centerOfCircle = velocity.normalized;
        Vector2 randomPoint = Random.insideUnitCircle;

        Vector3 displacement = new Vector3(randomPoint.x, randomPoint.y) * radiusOfCircle;

        Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, velocity);
        manager.transform.rotation = Quaternion.RotateTowards(manager.transform.rotation, toRotation, 720 * Time.deltaTime);

        Vector2 force = centerOfCircle + displacement;
        return force;
    }
  
}

