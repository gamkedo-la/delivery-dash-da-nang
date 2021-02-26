using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPSPlayerNavigation : MonoBehaviour
{
    [SerializeField]
    GraphPathfinding graphPathfinding; // Instance of GraphPathfinding that Player is connected to. There should be one for each human player.


    private void OnTriggerEnter(Collider other)
    {
        GraphNode currentObjective = graphPathfinding.objectiveNode;
        if (other.CompareTag("GraphNode") && currentObjective!=null)
        {
            //Debug.Log("collide with " + other.gameObject);

            GraphNode node;
            node = other.gameObject.GetComponent<GraphNode>();
            graphPathfinding.FindPath(node, currentObjective);
        }
    }



}
