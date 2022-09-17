using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollLeader : MonoBehaviour
{
    [SerializeField]
    private LeaderFollowingStateManager[] allAgents;

    public void NewRandomLeader() {
        if(allAgents.Length == 0)
        {
            return;
        }

        if (allAgents.Length == 1)
        {
            SetLeader(0);
            return;
        }

        int indexOfLeader = Random.Range(0, allAgents.Length - 1);
        SetLeader(indexOfLeader);
    }


    public void SetLeader(int index) {
        for (int i = 0; i < allAgents.Length; i++)
        {
            if(i == index)
            {
                allAgents[i].isLeader = true;
            }

            else
            {
                allAgents[i].isLeader = false;
                allAgents[i].leader = allAgents[index].gameObject;
            }
        }
    }

    public LeaderFollowingStateManager[] GetAllAgentsStateManager() {
        return allAgents;
    }
}
