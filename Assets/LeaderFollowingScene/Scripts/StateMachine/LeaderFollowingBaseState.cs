using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LeaderFollowingBaseState 
{
    public abstract void EnterState(LeaderFollowingStateManager manager);
    public abstract void UpdateState(LeaderFollowingStateManager manager);
}
