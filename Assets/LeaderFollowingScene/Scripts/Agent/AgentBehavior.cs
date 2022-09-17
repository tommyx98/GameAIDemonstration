using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentBehavior : MonoBehaviour
{
    [SerializeField]
    private RollLeader rollLeader;

    public List<GameObject> allAgents;

    public void ChangeAgentBehavior() {
        rollLeader.NewRandomLeader();

        foreach(LeaderFollowingStateManager agent in rollLeader.GetAllAgentsStateManager())
        {
            agent.SwitchState();
        }
    }
}
