using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class Connection : MonoBehaviour
{
    [HideInInspector]
    public GraphNode nodeA;

    public GraphNode nodeB;
    public GraphPathfinding graphPathfinding;

    public float connectionDistance
    {
        get { return Vector3.Distance(nodeA.worldPosition, nodeB.worldPosition); }
    }

    void OnDrawGizmos()
    {
        if(graphPathfinding.showGridConnections)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(nodeA.gameObject.transform.position, nodeB.gameObject.transform.position);
        }

    }

    private void Awake()
    {
        nodeA = GetComponentInParent<GraphNode>();
        graphPathfinding = FindObjectOfType<GraphPathfinding>();
        if(nodeB != null)
        {
            gameObject.name = ("Connection " + nodeA.name + "-" + nodeB.name);
        }
        else
        {
            gameObject.name = "null connection";
        }
    }

}
