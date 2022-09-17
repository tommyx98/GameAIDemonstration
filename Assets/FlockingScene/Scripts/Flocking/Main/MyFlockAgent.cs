using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class MyFlockAgent : MonoBehaviour
{
    private Collider2D _agentCollider;
    public Collider2D agentCollider { get { return _agentCollider; } }

    // Start is called before the first frame update
    void Start()
    {
        _agentCollider = GetComponent<Collider2D>();
    }

    public void AgentMover(Vector2 velocity) {
        transform.up = velocity;
        transform.position += (Vector3)velocity * Time.deltaTime;
    }
}
