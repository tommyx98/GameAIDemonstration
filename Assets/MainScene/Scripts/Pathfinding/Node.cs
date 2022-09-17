using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public int x;
    public int y;

    public bool isBlockedPath;
    public Vector3 pos;

    public Node parent;

    public int gCost; // cost of moving to next square
    public int hCost; // distance to goal from this node

    public int fCost { get { return gCost + hCost; } }

    public Node(bool _isBlockedPath, Vector3 _pos, int _x, int _y) {
        isBlockedPath = _isBlockedPath;
        pos = _pos;
        x = _x;
        y = _y;
    }
}
