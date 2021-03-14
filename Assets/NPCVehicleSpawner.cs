using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCVehicleSpawner : MonoBehaviour
{
    public GameObject parentObjectWithVehiclesToSpawn;
    public int numberOfVehiclesToSpawn;
    int RandNumber;
    public GameObject[] carToChoose;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("numberOfVehiclesToSpawn: " + numberOfVehiclesToSpawn);
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {



        int count = 0;
        while (count < numberOfVehiclesToSpawn)
        {
            //Debug.Log("numberOfVehiclesToSpawn: " + numberOfVehiclesToSpawn);
            GameObject ParentObjectWithVehicleWaypointChildren = Instantiate(parentObjectWithVehiclesToSpawn);
            //Debug.Log("ParentObjectWithVehicleWaypointChildren: " + ParentObjectWithVehicleWaypointChildren);
            Transform randomWaypointChildFromThisTransform = transform.GetChild(Random.Range(0, transform.childCount - 1));

            RandNumber = Random.Range(0, carToChoose.Length);
            carToChoose[RandNumber].SetActive(true);
            //Debug.Log("carToChoose[RandNumber]: " + carToChoose[RandNumber]);

            //randomWaypointChildFromThisTransform.GetComponent<NPCVehicleWaypointNavigation>().currentWaypoint = randomWaypointChildFromThisTransform.GetComponent<NPCVehicleWaypoint>();
            //Debug.Log(ParentObjectWithVehicleWaypointChildren.GetComponent<WaypointNavigation>().currentWaypoint);
            parentObjectWithVehiclesToSpawn.transform.position = randomWaypointChildFromThisTransform.position;
            //Debug.Log("randomWaypointChildFromThisTransform.position: " + randomWaypointChildFromThisTransform.position);
            Debug.Log("parentObjectWithVehiclesToSpawn.transform.position: " + parentObjectWithVehiclesToSpawn.transform.position);
            if (carToChoose[RandNumber].activeSelf)
            {
                print("chosen car is Active");
            }
            else
            {
                print("chosen car is not active");
            }    
            yield return new WaitForEndOfFrame();

            count++;
        }
    }
}
