using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connection : MonoBehaviour
{

    public GraphNode nodeA;
    public GraphNode nodeB;

    public float connectionDistance
    {
        get { return Vector3.Distance(nodeA.worldPosition, nodeB.worldPosition); }
    }



}
