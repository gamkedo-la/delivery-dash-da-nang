using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphNode : MonoBehaviour
{
    public List<Connection> connections;
    public Vector3 worldPosition;

    public List<GraphNode> neighbors;

    public int gCost;
    public int hCost;

    public GraphNode parent;

    public GraphNode(Vector3 _worldPos)
    {
        worldPosition = _worldPos;
    }

    public int fCost
    {
        get { return gCost + hCost; }
    }

    void Awake()
    {
        worldPosition = gameObject.transform.position;
        GetNeighbors();
    }

    public List<GraphNode> GetNeighbors()
    {
        for (int i = 0; i < connections.Count; i++)
        {
            if(this == connections[i].nodeA)
            {
                if (neighbors.Contains(connections[i].nodeB) == false)
                {
                    neighbors.Add(connections[i].nodeB);
                }
            }
            else
            {
                if(neighbors.Contains(connections[i].nodeA) == false)
                {
                    neighbors.Add(connections[i].nodeA);
                }
            }
        }
        return neighbors;
    }

}
