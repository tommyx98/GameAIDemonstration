using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentStateManager : MonoBehaviour
{
    [HideInInspector]
    public AgentBaseState currentState;

    [HideInInspector]
    public AgentBaseState wanderState = new AgentWanderState();

    [HideInInspector]
    public AgentBaseState fleeState = new AgentFleeState();

    [HideInInspector]
    public SpriteRenderer spriteRenderer;

    [HideInInspector]
    public Rigidbody2D rb;

    [Header("Flee")]
    public GameObject objectToFleeFrom;
    public float minFleeDistance;

    [Header("Sprites")]
    public Sprite wanderSprite;
    public Sprite fleeSprite;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        currentState = wanderState;
        currentState.EnterState(this);
        objectToFleeFrom = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(AgentBaseState state) {
        currentState = state;
        state.EnterState(this);
    }

    public float GetDistanceToFleeObject() {
        return Vector2.Distance(transform.position, objectToFleeFrom.transform.position);
    }

}
