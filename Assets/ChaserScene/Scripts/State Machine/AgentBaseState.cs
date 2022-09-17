using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AgentBaseState 
{
    public abstract void EnterState(AgentStateManager manager);
    public abstract void UpdateState(AgentStateManager manager);
}
