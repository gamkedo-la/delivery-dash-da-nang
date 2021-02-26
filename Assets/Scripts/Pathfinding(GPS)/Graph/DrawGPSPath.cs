using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawGPSPath : MonoBehaviour
{
    LineRenderer lineRenderer;

    GraphPathfinding graphPathfinding;



    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        graphPathfinding = FindObjectOfType<GraphPathfinding>();
    }

    private void Update()
    {
        List<GraphNode> pathNodes = graphPathfinding.path;
        var points = new Vector3[pathNodes.Count];

        for (int i = 0; i < pathNodes.Count; i++)
        {
            points[i] = pathNodes[i].worldPosition;
        }
        lineRenderer.positionCount = pathNodes.Count;
        lineRenderer.SetPositions(points);
    }
}
