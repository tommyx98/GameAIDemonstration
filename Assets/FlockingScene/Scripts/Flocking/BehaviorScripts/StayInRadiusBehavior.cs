using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/StayInRadius")]
public class StayInRadiusBehavior : MyFlockBehavior
{
    public Vector2 center;
    public float radius = 5f;
    public override Vector2 CalculateMove(MyFlockAgent agent, List<Transform> context, MyFlock flock) {
        Vector2 centerOffset = center - (Vector2)agent.transform.position;
        float a = centerOffset.magnitude / radius;

        if(a < 0.9f)
        {
            return Vector2.zero;
        }

        return centerOffset * a * a;
    }
}
