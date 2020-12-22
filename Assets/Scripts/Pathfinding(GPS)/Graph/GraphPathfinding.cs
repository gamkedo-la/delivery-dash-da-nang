using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphPathfinding : MonoBehaviour
{
    public Transform seeker;

    public GraphNode targetNode;

    public List<GraphNode> path;

    private void Update()
    {
        FindPath(seeker.position, targetNode);
    }

    void FindPath(Vector3 startPosition, GraphNode targetNode)
    {
        GraphNode startNode = new GraphNode(startPosition); //Construct new node or simply find nearest node and start from there?

        List<GraphNode> openSet = new List<GraphNode>();
        List<GraphNode> closedSet = new List<GraphNode>();

        while(openSet.Count > 0)
        {
            GraphNode node = openSet[0];
            for (int i = 1; i < openSet.Count; i++)
            {
                if(openSet[i].fCost < node.fCost || openSet[i].fCost == node.fCost)
                {
                    if(openSet[i].hCost < node.hCost)
                    {
                        node = openSet[i];
                    }
                }
            }

            openSet.Remove(node);
            closedSet.Add(node);

            if(node == targetNode)
            {
                RetracePath(startNode, targetNode);
                return;
            }

            //Loop through connections to find shortest path
            foreach(GraphNode neighbor in node.GetNeighbors())
            {
                if (closedSet.Contains(neighbor))
                {
                    continue;
                }

                int newMovementCostToNeighbor = node.gCost + GetDistance(node, neighbor);
                if(newMovementCostToNeighbor < neighbor.gCost || !openSet.Contains(neighbor))
                {
                    neighbor.gCost = newMovementCostToNeighbor;
                    neighbor.hCost = GetDistance(neighbor, targetNode);
                    neighbor.parent = node;

                    if (!openSet.Contains(neighbor))
                    {
                        openSet.Add(neighbor);
                    }
                }                
            }
        }
    }

    int GetDistance(GraphNode nodeA, GraphNode nodeB)
    {
        return (int)Vector3.Distance(nodeA.worldPosition, nodeB.worldPosition);
    }

    void RetracePath(GraphNode startNode, GraphNode endNode)
    {
        GraphNode currentNode = endNode;
        while(currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }
        path.Reverse();
    }

    private void OnDrawGizmos()
    {
        if(path != null)
        {
            for (int i = 0; i < path.Count; i++)
            {
                Gizmos.color = Color.black;
                Gizmos.DrawLine(path[i].worldPosition, path[i + 1].worldPosition);
            }
        }
    }
}
