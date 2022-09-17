using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Separation")]
public class SeparationBehavior : MyFlockBehavior
{
    public override Vector2 CalculateMove(MyFlockAgent agent, List<Transform> context, MyFlock flock) {
               
        if (context.Count == 0)
        {
            return Vector2.zero;
        }

       
        Vector2 separationMove = Vector2.zero;
        int nSeparation = 0;

        foreach (Transform item in context)
        {
            if(Vector2.SqrMagnitude(item.position - agent.transform.position) < flock.squareAvoidanceRadius)
            {
                nSeparation++;
                separationMove += (Vector2)(agent.transform.position - item.position);
            }           
        }

        if (nSeparation > 0)
        {
            separationMove /= nSeparation;
        }

        return separationMove;
    }
}
