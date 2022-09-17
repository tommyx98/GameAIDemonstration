using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActivePath
{
    PATH1,
    PATH2,
    PATH3,
    PATH4,
    NONE
}
public class Pathfinder : MonoBehaviour
{
    public Grid grid;
    public Transform startPosition;
    public GameObject pathMarker;

    [Header("Exits")]
    public Transform exit1;
    public Transform exit2;
    public Transform exit3;
    public Transform exit4;

    [HideInInspector]public List<GameObject> drawnPathObjects;
    private Vector3 lastPosChecked;
    private Vector3 currentPos;
    private bool move = true;
    private ActivePath active = ActivePath.NONE;


    private void Start() {
        lastPosChecked = startPosition.position;
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = startPosition.position;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CalculatePath(startPosition.position, exit1.position, ActivePath.PATH1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CalculatePath(startPosition.position, exit2.position, ActivePath.PATH2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CalculatePath(startPosition.position, exit3.position, ActivePath.PATH3);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            CalculatePath(startPosition.position, exit4.position, ActivePath.PATH4);
        }
    }

    private void CalculatePath(Vector3 startPos, Vector3 targetPos, ActivePath newActivePath) {
        if (lastPosChecked != currentPos || active != newActivePath)
        {
            lastPosChecked = currentPos;
            FindPath(startPos, targetPos);
            DrawPath(pathMarker);
            active = newActivePath;
            //StartCoroutine(PathRemover());
        }
    }

    private void FindPath(Vector3 startPos, Vector3 targetPos) {
        Node startNode = grid.NodeFromWorldPosition(startPos);
        Node targetNode = grid.NodeFromWorldPosition(targetPos);

        List<Node> openList = new List<Node>();
        HashSet<Node> closedList = new HashSet<Node>();

        openList.Add(startNode);

        while(openList.Count > 0)
        {
            Node currentNode = openList[0];

            for(int i = 1; i < openList.Count; i++)
            {
                if(openList[i].fCost < currentNode.fCost || openList[i].fCost == currentNode.fCost && openList[i].hCost < currentNode.hCost) {
                    currentNode = openList[i];
                }
            }
            openList.Remove(currentNode);
            closedList.Add(currentNode);

            if(currentNode == targetNode)
            {
                GetFinalPath(startNode, targetNode);
                break;
            }

            foreach(Node neighborNode in grid.GetNeighborNodes(currentNode))
            {
                if(!neighborNode.isBlockedPath || closedList.Contains(neighborNode))
                {
                    continue;
                }

                int moveCost = currentNode.gCost + GetManhattenDistance(currentNode, neighborNode);

                if (moveCost < neighborNode.gCost || !openList.Contains(neighborNode))
                {
                    neighborNode.gCost = moveCost;
                    neighborNode.hCost = GetManhattenDistance(neighborNode, targetNode);
                    neighborNode.parent = currentNode;

                    if (!openList.Contains(neighborNode))
                    {
                        openList.Add(neighborNode);
                    }
                }
            }
        }
    }

    private void GetFinalPath(Node startNode, Node endNode) {
        List<Node> finalPath = new List<Node>();
        Node currentNode = endNode;

        while(currentNode != startNode)
        {
            finalPath.Add(currentNode);
            currentNode = currentNode.parent;
        }

        finalPath.Reverse();

        grid.finalPath = finalPath;
    }

    private int GetManhattenDistance(Node nodeA, Node nodeB) {
        int x = Mathf.Abs(nodeA.x - nodeB.x);
        int y = Mathf.Abs(nodeA.y - nodeB.y);

        return x + y;
    }

    private void DrawPath(GameObject objectToUse) {

        // if path already drawn and user want to draw new path, first delete existing path
        foreach (GameObject drawnPath in drawnPathObjects)
        {
            Destroy(drawnPath);
        }
         // empty list of path objects before inserting new
        drawnPathObjects.Clear();
        
        foreach (Node node in grid.finalPath)
        {
            GameObject obj = Instantiate(objectToUse, node.pos, Quaternion.identity); 
            drawnPathObjects.Add(obj);
        }
    }

    private IEnumerator PathRemover() {
        yield return new WaitForSeconds(1f);
        foreach (GameObject drawnPath in drawnPathObjects)
        {
            Destroy(drawnPath);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
