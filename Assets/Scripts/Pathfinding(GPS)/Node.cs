using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Pathfinding based on Sebasian Lague's A* Pathfinding series

public class Node
{

    public bool driveable;
    public Vector3 worldPosition;

    public Node(bool _driveable, Vector3 _worldPos)
    {
        driveable = _driveable;
        worldPosition = _worldPos;
    }

}
