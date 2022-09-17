using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Alignment")]
public class AlignmentBehavior : MyFlockBehavior
{
    public override Vector2 CalculateMove(MyFlockAgent agent, List<Transform> context, MyFlock flock) {
              
        if (context.Count == 0)
        {
            return agent.transform.up;
        }

        Vector2 alignmentMove = Vector2.zero;

        foreach (Transform t in context)
        {
            alignmentMove += (Vector2)t.transform.up;
        }

        alignmentMove /= context.Count;

        return alignmentMove;
    }
}
