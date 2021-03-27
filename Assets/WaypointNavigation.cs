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

    //lưdaskgufhaikuhawliukfgha
    //public AudioClip danielleScreamAudioClip, scream2, scream3, scream4;
    //public List<AudioClip> listOfScreams = new List<AudioClip>();

    private void Awake()
    {
        controller = GetComponent<PedestrianCharacterController>();
    }

    void playRandomScream()
    {

    }

    void Start()
    {
        //int randomChildIdx = Random.Range(0, carSpawner.transform.childCount - 1);
        //Waypoint startingWaypointForInstantiation = carSpawner.transform.GetChild(randomChildIdx);
        //startingWaypointForInstantiation = startingWaypointForInstantiation;
        direction = Mathf.RoundToInt(Random.Range(0f, 1f));
        //Debug.Log(startingWaypointForInstantiation);
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
