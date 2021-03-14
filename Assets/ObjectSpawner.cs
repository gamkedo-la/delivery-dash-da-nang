using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject notThisParentPrefab;
    public int objectsToSpawn;

    public GameObject testEmptyGameObjectForPositioning;


    DetermineWhichCar determineWhichCarScript;

    private void Awake()
    {
        determineWhichCarScript = notThisParentPrefab.GetComponent<DetermineWhichCar>();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {

        

    int count = 0;
        while (count<objectsToSpawn)
        {
            
            GameObject notThisParentPrefabWithTransformOfManyVehicularChildren = Instantiate(notThisParentPrefab);
            //
            Transform waypointChildFromThisTransform = transform.GetChild(Random.Range(0, transform.childCount - 1));
            
            
            
            //waypointChildFromThisTransform.GetComponent<WaypointNavigation>().currentWaypoint = waypointChildFromThisTransform.GetComponent<Waypoint>();
            //Debug.Log(obj.GetComponent<WaypointNavigation>().currentWaypoint);
            notThisParentPrefabWithTransformOfManyVehicularChildren.transform.position = waypointChildFromThisTransform.position;

            if (gameObject.name == "CarSpawner")
            {
                //Debug.Log(waypointChildFromThisTransform.transform.position);
                //Debug.Log(notThisParentPrefabWithTransformOfManyVehicularChildren.transform.position);
                //Debug.Log(determineWhichCarScript);
                //Debug.Log(determineWhichCarScript.chosenCar);
                //if (determineWhichCarScript.chosenCar.activeSelf)
                //{
                //    print("chosen car is Active");
                //    Debug.Log("chosenCar: " + determineWhichCarScript.chosenCar);
                //}
                //else
                //{
                //    print("chosen car is not active");
                //}
            }

            

            yield return new WaitForEndOfFrame();

            count++;
        }
    }
}
