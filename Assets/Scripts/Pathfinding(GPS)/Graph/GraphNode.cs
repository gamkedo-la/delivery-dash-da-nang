using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphNode : MonoBehaviour
{
    Dictionary<GraphNode, int> distCosts;

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
    public int distTo(GraphNode dest)
    {
        if (distCosts.ContainsKey(dest) == false)
        {
            int dist = (int)Vector3.Distance(worldPosition, dest.worldPosition);
            distCosts.Add(dest, dist);
            dest.LearnDist(this, dist);
        }
        return distCosts[dest];
    }

    public void LearnDist(GraphNode from, int cost)
    {
        if (distCosts.ContainsKey(from) == false)
        {
            distCosts.Add(from, cost);
        }

    }

    public int fCost
    {
        get { return gCost + hCost; }
    }

    void Awake()
    {
        distCosts = new Dictionary<GraphNode, int>();
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
