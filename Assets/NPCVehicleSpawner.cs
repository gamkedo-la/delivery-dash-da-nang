using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCVehicleSpawner : MonoBehaviour
{
    public GameObject parentObjectWithVehiclesToSpawn;
    public int vehiclesToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {



        int count = 0;
        while (count < vehiclesToSpawn)
        {

            GameObject ParentObjectWithVehicleWaypointChildren = Instantiate(parentObjectWithVehiclesToSpawn);
            //
            Transform randomWaypointChildFromThisTransform = transform.GetChild(Random.Range(0, transform.childCount - 1));

            if (gameObject.name == "NgoThiSiVehicleWaypoints")
            {
                Debug.Log("inside car spawner while loop waypointChildFromThisTransform");
                Debug.Log(parentObjectWithVehiclesToSpawn);
                Debug.Log(randomWaypointChildFromThisTransform);
            }
            randomWaypointChildFromThisTransform.GetComponent<NPCVehicleWaypointNavigation>().currentWaypoint = randomWaypointChildFromThisTransform.GetComponent<NPCVehicleWaypoint>();
            //Debug.Log(obj.GetComponent<WaypointNavigation>().currentWaypoint);
            parentObjectWithVehiclesToSpawn.transform.position = randomWaypointChildFromThisTransform.position;

            yield return new WaitForEndOfFrame();

            count++;
        }
    }
}
