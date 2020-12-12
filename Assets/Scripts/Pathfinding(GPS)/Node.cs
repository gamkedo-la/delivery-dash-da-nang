using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Pathfinding based on Sebasian Lague's A* Pathfinding series

public class Node
{

    public bool driveable;
    public Vector3 worldPosition;

    public int gCost;
    public int hCost;

    public int gridX;
    public int gridY;

    public Node parent;

    public Node(bool _driveable, Vector3 _worldPos, int _gridX, int _gridY)
    {
        driveable = _driveable;
        worldPosition = _worldPos;
        gridX = _gridX;
        gridY = _gridY;
    }

    public int fCost
    {
       get { return gCost + hCost; }
    }

}
