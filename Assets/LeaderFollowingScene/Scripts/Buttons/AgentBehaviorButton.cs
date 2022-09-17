using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgentBehaviorButton : MonoBehaviour
{
    [SerializeField]
    private Button followButton; // this button starts as selected as it is the predefined behavior

    [SerializeField]
    private AgentBehavior agentBehavior1;
    private void Start() {
        followButton.Select();
        followButton.onClick.Invoke();
    }
    public void ChangeAgentBehavior(AgentBehavior agentBehavior) {
        agentBehavior1.ChangeAgentBehavior();
    }
}
