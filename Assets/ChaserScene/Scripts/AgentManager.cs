using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentManager : MonoBehaviour
{
    public GameObject agentPrefab;
    public GameObject winScreen;

    [Range(1, 10)]
    public int startingSize = 4;

    private GameObject[] allAgents;
    private bool playerWon;

    // Start is called before the first frame update
    void Start()
    {
        allAgents = new GameObject[startingSize];
        playerWon = false;
        SpawnAllAgents();
    }

    private void Update() {
        DestructionCheck();
        CheckForActivationOfWinScreen();
    }

    private void SpawnAllAgents() {
        for (int i = 0; i < allAgents.Length; i++)
        {
            GameObject newAgent = Instantiate(agentPrefab,
                Random.insideUnitCircle * startingSize,
                Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)),
                transform);

            newAgent.name = "Agent " + i;
            allAgents[i] = newAgent;
        }
    }

    private void DestructionCheck() {
        for(int i = 0; i < allAgents.Length; i++)
        {
            if(allAgents[i] != null && allAgents[i].tag == "Destroy")
            {
                Destroy(allAgents[i]);
                allAgents[i] = null;
            }
        }
    }

    private void CheckForActivationOfWinScreen() {
        int emptyObjects = 0;

        foreach(GameObject agent in allAgents)
        {
            if(agent == null)
            {
                emptyObjects++;
            }
        }

        if (emptyObjects == allAgents.Length && !playerWon)
        {
            playerWon = true;
            Time.timeScale = 0f;
            winScreen.SetActive(true);
        }
    }
}
