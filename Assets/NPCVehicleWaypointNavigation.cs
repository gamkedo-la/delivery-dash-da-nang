using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCVehicleWaypointNavigation : MonoBehaviour
{
    CarController NPCCarControllerScript;
    public NPCVehicleWaypoint startingWaypointForInstantiation;
    public GameObject carSpawner;
    public NPCVehicleWaypoint currentWaypoint;
    int direction;

    //lưdaskgufhaikuhawliukfgha
    //public AudioClip danielleScreamAudioClip, scream2, scream3, scream4;
    //public List<AudioClip> listOfScreams = new List<AudioClip>();

    private void Awake()
    {
        NPCCarControllerScript = GetComponent<CarController>();
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
            NPCCarControllerScript.SetDestination(currentWaypoint.GetPosition());
        }
    }


    void Update()
    {
        //if (NPCCarControllerScript.reachedDestination)
        //{
        //    bool shouldBranch = false;
        //    if (currentWaypoint != null)
        //    {
        //        if (currentWaypoint.branches != null && currentWaypoint.branches.Count > 0)
        //        {
        //            shouldBranch = Random.Range(0f, 1f) <= currentWaypoint.branchRatio ? true : false;
        //        }

        //        if (shouldBranch)
        //        {
        //            currentWaypoint = currentWaypoint.branches[Random.Range(0, currentWaypoint.branches.Count - 1)];
        //        }
        //        else
        //        {
        //            if (direction == 0)
        //            {
        //                if (currentWaypoint.nextWayPoint != null)
        //                {
        //                    currentWaypoint = currentWaypoint.nextWayPoint;
        //                }
        //                else
        //                {
        //                    currentWaypoint = currentWaypoint.previousWayPoint;
        //                    direction = 1;
        //                }
        //            }
        //            else if (direction == 1)
        //            {
        //                if (currentWaypoint.previousWayPoint != null)
        //                {
        //                    currentWaypoint = currentWaypoint.previousWayPoint;
        //                }
        //                else
        //                {
        //                    currentWaypoint = currentWaypoint.nextWayPoint;
        //                    direction = 0;
        //                }
        //            }
        //        }
        //        if (currentWaypoint != null)
        //        {
        //            NPCCarControllerScript.SetDestination(currentWaypoint.GetPosition());
        //        }
        //    }

        //}
    }
}
