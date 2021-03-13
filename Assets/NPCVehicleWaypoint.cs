using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCVehicleWaypoint : MonoBehaviour
{
    public NPCVehicleWaypoint previousWaypoint;
    public NPCVehicleWaypoint nextWaypoint;

    [Range(0f,40f)]
    public float width = 9f;
    public Vector3 GetPosition()
    {
        Vector3 minBound = transform.position + transform.right * width / 2f;
        Vector3 maxBound = transform.position - transform.right * width / 2f;

        return Vector3.Lerp(minBound, maxBound, Random.Range(0f, 1f));
    }    
}
