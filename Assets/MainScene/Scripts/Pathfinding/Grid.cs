using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public Transform startPosition;
    public LayerMask wallMask;
    public Vector2 gridWorldSize;
    public float nodeRadius;
    public float distance;
    Node[,] grid;
    public List<Node> finalPath;

    private float nodeDiameter;
    private int gridSizeX, gridSizeY;

    private void Start() {
        nodeDiameter = nodeRadius *2;
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);
        CreateGrid();
    }

    private void CreateGrid() {
        grid = new Node[gridSizeX, gridSizeY];
        Vector3 bottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.forward * gridWorldSize.y / 2;

        for (int y = 0; y < gridSizeX; y++) {
            for (int x = 0; x < gridSizeX; x++)
            {
                Vector3 worldPoint = bottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.forward * (y * nodeDiameter + nodeRadius);
                bool blockedPath = true;

                if(Physics.CheckSphere(worldPoint, nodeRadius, wallMask))
                {
                    blockedPath = false;
                }

                grid[x, y] = new Node(blockedPath, worldPoint, x, y);
            }
        }
    }

    public Node NodeFromWorldPosition(Vector3 worldPosition) {
        float xPoint = ((worldPosition.x + gridWorldSize.x / 2) / gridWorldSize.x);
        float yPoint = ((worldPosition.z + gridWorldSize.y / 2) / gridWorldSize.y);
        xPoint = Mathf.Clamp01(xPoint);
        yPoint = Mathf.Clamp01(yPoint);

        int x = Mathf.RoundToInt((gridSizeX - 1) * xPoint);
        int y = Mathf.RoundToInt((gridSizeY - 1) * yPoint);

        return grid[x, y];
    }

    public List<Node> GetNeighborNodes(Node node) {
        List<Node> neighboringNodes = new List<Node>();

        for(int x = -1; x <= 1; x++)
        {
            for(int y = -1; y <= 1; y++)
            {
                if(x == 0 && y == 0)
                {
                    continue;
                }

                int checkX = node.x + x;
                int checkY = node.y + y;

                if(checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY)
                {
                    neighboringNodes.Add(grid[checkX, checkY]);
                }
            }
        }
        return neighboringNodes;
    }

    private void OnDrawGizmos() {
        //return;

        Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, 1, gridWorldSize.y));

        if(grid != null)
        {
            foreach(Node node in grid)
            {
                if (node.isBlockedPath)
                {
                    Gizmos.color = Color.white;
                }

                else
                {
                    Gizmos.color = Color.yellow;
                }

                if(finalPath != null)
                {
                    Gizmos.color = Color.red;
                }

                Gizmos.DrawCube(node.pos, Vector3.one * (nodeDiameter - distance));
            }
        }
    }
}
