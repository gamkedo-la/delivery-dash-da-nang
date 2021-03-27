using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointNavigation : MonoBehaviour
{
    PedestrianCharacterController controller;
    public Waypoint startingWaypointForInstantiation;
    public GameObject carSpawner;
    public Waypoint currentWaypoint;
    int direction;

   // public Waypoint[] waypointOptions;

    private void Awake()
    {
        controller = GetComponent<PedestrianCharacterController>();
        GetComponent<NavMeshAgent>().enabled = false;
    /*    int RandPosition = Random.Range(0, waypointOptions.Length - 1);
        controller.transform.position = waypointOptions[RandPosition].transform.position;
        currentWaypoint = waypointOptions[RandPosition];
    */
        StartCoroutine(Waiting());
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

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(1);
        GetComponent<NavMeshAgent>().enabled = true;
    }
}
