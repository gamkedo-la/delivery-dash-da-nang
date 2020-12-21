using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphPathfinding : MonoBehaviour
{
    public Transform seeker;

    public GraphNode targetNode;

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
                //trace path
                return;
            }

            //Loop through connections to find shortest path
            foreach(GraphNode neighbor in node.neighbors)
            {
                if (closedSet.Contains(neighbor))
                {
                    continue;
                }

                float newMovementCostToNeighbor = GetDistance(node, neighbor);

                //Do I make this into the new gCost? 
            }

        }

        float GetDistance(GraphNode nodeA, GraphNode nodeB)
        {
            return Vector3.Distance(nodeA.worldPosition, nodeB.worldPosition);
        }
    }
}
