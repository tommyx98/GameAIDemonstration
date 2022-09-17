using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFlock : MonoBehaviour
{
    public MyFlockAgent agentPrefab;
    [HideInInspector]public List<MyFlockAgent> allAgents = new List<MyFlockAgent>();
    public MyFlockBehavior behavior;

    [Range(1, 100)]
    public int startingSize = 30;
    const float agentDensity = 0.08f;

    [Range(1f, 100f)]
    public float driveFactor = 10f;
    [Range(1f, 100f)]
    public float maxSpeed = 5f;
    [Range(1f, 10f)]
    public float neighbourRadius = 1.5f;
    [Range(0f, 1f)]
    public float avoidanceRadiusMultiplier = 0.5f;

    private float squareMaxSpeed;
    private float squareNeighbourRadius;
    private float _squareAvoidanceRadius;
    public float squareAvoidanceRadius { get { return _squareAvoidanceRadius; } }

    // Start is called before the first frame update
    void Start()
    {
        squareMaxSpeed = maxSpeed * maxSpeed;
        squareNeighbourRadius = neighbourRadius * neighbourRadius;
        _squareAvoidanceRadius = squareNeighbourRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;

        SpawnAgents();
    }

    // Update is called once per frame
    void Update()
    {
        MoveAgents();
    }

    private List<Transform> GetNearbyAgents(MyFlockAgent agent) {
        List<Transform> context = new List<Transform>();
        Collider2D[] contextColliders = Physics2D.OverlapCircleAll(agent.transform.position, neighbourRadius);
        
        foreach(Collider2D c in contextColliders)
        {
            if(c != agent.agentCollider)
            {
                context.Add(c.transform);
            }
        }

        return context;
    }

    private void SpawnAgents() {
        for (int i = 0; i < startingSize; i++)
        {
            MyFlockAgent agentToBeSpawned = Instantiate(agentPrefab,
                Random.insideUnitCircle * startingSize * agentDensity,
                Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)),
                transform);

            agentToBeSpawned.name = "Agent " + i;
            allAgents.Add(agentToBeSpawned);
        }
    }

    private void MoveAgents() {
        foreach (MyFlockAgent agent in allAgents)
        {
            List<Transform> context = GetNearbyAgents(agent);

            Vector2 agentMove = behavior.CalculateMove(agent, context, this);
            agentMove *= driveFactor;

            if (agentMove.sqrMagnitude > squareMaxSpeed)
            {
                agentMove = agentMove.normalized * maxSpeed;
            }

            agent.AgentMover(agentMove);
        }
    }
}
