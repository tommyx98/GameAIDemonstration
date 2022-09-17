using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Obstacle Avoidance")]
public class ObstacleAvoidance : MyFlockBehavior
{
    [SerializeField]
    private float xSize;
    [SerializeField]
    private float ySize;
    [SerializeField]
    private float maxSeeAhead;
    [SerializeField]
    private LayerMask avoid;
    private bool obstaclesFound = false;
    private List<GameObject> obstacles;
    public override Vector2 CalculateMove(MyFlockAgent agent, List<Transform> context, MyFlock flock) {

        if (!obstaclesFound)
        {
            obstacles = GameObject.FindWithTag("ObstacleHolder").GetComponent<ObstacleHolder>().allObstacles;
            obstaclesFound = true;
        }

        if (obstacles.Count == 0)
        {
            return Vector2.zero;
        }
        Vector2 sum = Vector2.zero;
        int count = 0;
        for(int i = 0; i < obstacles.Count; i++)
        {
            float distance = Vector2.Distance(agent.transform.position, obstacles[i].transform.position);

            if(distance > 0 && distance < 1)
            {
                Vector2 difference = agent.transform.position - obstacles[i].transform.position;
                difference.Normalize();
                difference = difference / distance;
                sum += difference * 2;
                count++;
            }
        }
        if(count > 0)
        {
            sum = sum / count;
        }
        return sum;
    }
}
