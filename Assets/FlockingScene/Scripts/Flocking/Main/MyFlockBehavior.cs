using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class MyFlockBehavior : ScriptableObject
{
    public abstract Vector2 CalculateMove(MyFlockAgent agent, List<Transform> context, MyFlock flock);
}
