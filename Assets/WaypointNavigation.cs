using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointNavigation : MonoBehaviour
{
    PedestrianCharacterController controller;
    public Waypoint startingWaypointForInstantiation;
    public GameObject carSpawner;
    public Waypoint currentWaypoint;
    int direction;

    private void Awake()
    {
        controller = GetComponent<PedestrianCharacterController>();
    }

    void Start()
    {
        if (currentWaypoint != null)
        {
            controller.SetDestination(currentWaypoint.GetPosition());
        }
    }


    void Update()
    {
        if (controller.reachedDestination)
        {
            currentWaypoint = currentWaypoint.nextWayPoint;
            controller.SetDestination(currentWaypoint.GetPosition());
        }
    }
}
