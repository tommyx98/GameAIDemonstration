using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderFollowingFollowState : LeaderFollowingBaseState
{
    private float speed = 2f;
    private float minimumLeaderDistance = 2f;

    private float minimumSeperationDistance = 1.5f;

    private float slowDownRange = 7f;
    private float maxSpeed = 5f;
    public override void EnterState(LeaderFollowingStateManager manager) {
        if (manager.isLeader)
        {
            manager.spriteRenderer.sprite = manager.leaderSprite;
        }

        else
        {
            manager.spriteRenderer.sprite = manager.notLeaderSprite;
        }
    }

    public override void UpdateState(LeaderFollowingStateManager manager) {

        if (manager.isLeader)
        {
            Leader(manager);
        }

        else
        {
            Arrival(manager);
            Separation(manager);
            manager.transform.eulerAngles = Vector2.zero; // Why? It looks cooler thats why!
        }
    }

    // simulate scatter behavior without actually changing state
    private void Leader(LeaderFollowingStateManager manager) {
        manager.scatterState.UpdateState(manager);
    }

    private void ToLeader(LeaderFollowingStateManager manager) {
        if (Vector2.Distance(manager.transform.position, manager.leader.transform.position) < minimumLeaderDistance)
        {
            return;
        }

        Vector3 dir = manager.transform.position - manager.leader.transform.position;
        dir = dir.normalized;
        manager.transform.position -= dir * Time.deltaTime * speed;
    }

    private void Separation(LeaderFollowingStateManager manager) {
        foreach(GameObject current in manager.allAgents)
        {
            if(current != manager.gameObject)
            {
                if(Vector2.Distance(current.transform.position, manager.transform.position) < minimumSeperationDistance)
                {
                    Vector3 dir = manager.transform.position - current.transform.position;
                    dir = dir.normalized;
                    manager.transform.position += dir * Time.deltaTime * speed;
                }
            }
        }
    }

    private void Arrival(LeaderFollowingStateManager manager) {
        Vector2 desired = manager.leader.transform.position - manager.transform.position;
        float dist = Vector2.Distance(manager.transform.position, manager.leader.transform.position);
        desired.Normalize();

        if(dist < slowDownRange)
        {
            float coef = (dist / slowDownRange) * maxSpeed;
            desired *= coef;
        }

        else
        {
            desired *= maxSpeed;
        }

        manager.transform.position += (Vector3)desired * Time.deltaTime;
    }
}
