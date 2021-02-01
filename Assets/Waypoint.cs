using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Waypoint previousWayPoint;
    public Waypoint nextWayPoint;

    [Range(0f,10f)]
    public float width = 9f;
    public List<Waypoint> branches;

    [Range(0f, 1f)]
    public float branchRatio = 0.5f;

    public Vector3 GetPosition()
    {
        Vector3 minBound = transform.position + transform.right * width / 2f;
        Vector3 maxBound = transform.position - transform.right * width / 2f;

        return Vector3.Lerp(minBound, maxBound, Random.Range(0f, 1f));
    }
}
