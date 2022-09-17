using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderFollowingStateManager : MonoBehaviour
{
    [HideInInspector]
    public LeaderFollowingBaseState currentState;

    [HideInInspector]
    public LeaderFollowingBaseState followState = new LeaderFollowingFollowState();

    [HideInInspector]
    public LeaderFollowingBaseState scatterState = new LeaderFollowingScatterState();

    [HideInInspector]
    public bool isLeader = false;

    [HideInInspector]
    public GameObject leader;

    [HideInInspector]
    public List<GameObject> allAgents;

    [HideInInspector]
    public SpriteRenderer spriteRenderer;

    [Header("Sprites")]
    public Sprite notLeaderSprite;
    public Sprite leaderSprite;

    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        allAgents = GameObject.Find("AgentManager").GetComponent<AgentBehavior>().allAgents;
        currentState = scatterState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(LeaderFollowingBaseState state) {
        currentState = state;
        state.EnterState(this);
    }

    public void SwitchState() {
        if (currentState.GetType() == typeof(LeaderFollowingFollowState))
        {
            currentState = scatterState;
            currentState.EnterState(this);
        }

        else
        {
            currentState = followState;
            currentState.EnterState(this);
        }
    }
}
