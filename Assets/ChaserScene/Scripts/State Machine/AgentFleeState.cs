using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System;

public class AgentFleeState : AgentBaseState
{
    private float speed = 5f;

    // put state specific behavior here, animation etc.
    public override void EnterState(AgentStateManager manager) {
        manager.spriteRenderer.sprite = manager.fleeSprite;
    }

    public override void UpdateState(AgentStateManager manager) {
        if (manager.GetDistanceToFleeObject() > manager.minFleeDistance)
        {
            manager.SwitchState(manager.wanderState);
        }

        // flee logic
        else
        {
            Flee(manager);
        }
    }

    private void Flee(AgentStateManager manager) {
        Vector3 dir = manager.transform.position - manager.objectToFleeFrom.transform.position;
        dir = dir.normalized;
        manager.transform.position += dir * Time.deltaTime * speed;

        // rotate towards moving direction
        Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, dir);
        manager.transform.rotation = Quaternion.RotateTowards(manager.transform.rotation, toRotation, 720 * Time.deltaTime);
    }
}
