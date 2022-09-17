using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/SteeredCohesion")]
public class SteeredCohesion : MyFlockBehavior
{
    private Vector2 velocity;
    public float smoothTime = 0.5f;
    public override Vector2 CalculateMove(MyFlockAgent agent, List<Transform> context, MyFlock flock) {
               
        if (context.Count == 0)
        {
            return Vector2.zero;
        }

        Vector2 cohesionMove = Vector2.zero;

        foreach (Transform t in context)
        {
            cohesionMove += (Vector2)t.position;
        }

        cohesionMove /= context.Count;

        cohesionMove -= (Vector2)agent.transform.position;
        cohesionMove = Vector2.SmoothDamp(agent.transform.up, cohesionMove, ref velocity, smoothTime);

        return cohesionMove;
    }
}
