using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public List<Transform> allPoints = new List<Transform>();
    public List<Vector2> nodes;

    // Start is called before the first frame update
    void Start()
    {
        nodes = CopyTransformsToVector2List(allPoints);
    }

    public void AddNode(Vector2 node) {
        nodes.Add(node);
    }

    public List<Vector2> GetNodes() {
        return nodes;
    }

    private List<Vector2> CopyTransformsToVector2List(List<Transform> transformList) {
        List<Vector2> vector2List = new List<Vector2>();
        foreach (Transform t in transformList)
        {
            vector2List.Add(t.position);
        }
        return vector2List;
    }
}
