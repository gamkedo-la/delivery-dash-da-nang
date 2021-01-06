using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphPathfinding : MonoBehaviour
{
    private GraphNode solvedForStart, solvedForTarget;

    public GraphNode seeker;

    public GraphNode targetNode;

    private List<GraphNode> allNodes;

    public List<GraphNode> path;

    public bool showGridConnections = true;

    private Transform playerLocation;
    public GraphNode nearestNode = null;

    private void Awake()
    {
        GameObject[] waypointGoes = GameObject.FindGameObjectsWithTag("GraphNode");
        allNodes = new List<GraphNode>();
        for (int i = 0; i < waypointGoes.Length; i++)
        {
            allNodes.Add(waypointGoes[i].GetComponent<GraphNode>());
        }

        playerLocation = FindObjectOfType<ScooterDrive>().GetComponent<Transform>();

    }

    private void Update()
    {
        FindPath(seeker, targetNode);
        if (Input.GetMouseButtonDown(0))
        {
            nearestNode = FindNearestNode(playerLocation);
        }
    }

    void FindPath(GraphNode startNode, GraphNode targetNode)
    {
        if(startNode == solvedForStart && targetNode == solvedForTarget)
        {
            return;
        }

        List<GraphNode> openSet = new List<GraphNode>();
        List<GraphNode> closedSet = new List<GraphNode>();
        //openSet := {start}
        openSet.Add(startNode);

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
                solvedForStart = startNode;
                solvedForTarget = targetNode;
                RetracePath(startNode, targetNode);
                return;
            }

            //Loop through connections to find shortest path
            //for each neighbor of current
            foreach (GraphNode neighbor in node.GetNeighbors())
            {
                if (closedSet.Contains(neighbor))
                {
                    continue;
                }
                //tentative_gScore := gScore[current] + d(current, neighbor)
                int newMovementCostToNeighbor = node.gCost + GetDistance(node, neighbor);
                //if tentative_gScore < gScore[neighbor]
                if (newMovementCostToNeighbor < neighbor.gCost || !openSet.Contains(neighbor))
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
        return nodeA.distTo(nodeB);
    }

    void RetracePath(GraphNode startNode, GraphNode endNode)
    {
        path.Clear();
        GraphNode currentNode = endNode;
        while(currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }
        path.Add(startNode);
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

    public GraphNode FindNearestNode(Transform transform)
    {
        
        float checkRadius = 10f;
        LayerMask nodeLayer = LayerMask.GetMask("Node");
        Collider[] nodeColliders = Physics.OverlapSphere(transform.position, checkRadius, nodeLayer);
        
        while (nearestNode == null)
        {
            //Debug.Log("looping at " + checkRadius);

            if (nodeColliders[0] != null)
            {
                nearestNode = nodeColliders[0].GetComponent<GraphNode>();
                Debug.Log(nodeColliders[0]);   
                return nearestNode;

                /*if (path.Contains(nearestNode))
                {
                    return nearestNode;
                }
                else
                {
                    path.Add(nearestNode);                    
                }*/
            }
            checkRadius ++;
        }
        return nearestNode;
    }
}
