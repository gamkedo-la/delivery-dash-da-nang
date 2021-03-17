using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject parentObjectWithVariedPrefabsPublicHierarchyReference;
    public int objectsToSpawn;

    public GameObject testEmptyGameObjectForPositioning;
    private GameObject testPoint;


    DetermineWhichCar determineWhichCarScript;

    private void Awake()
    {
        determineWhichCarScript = parentObjectWithVariedPrefabsPublicHierarchyReference.GetComponent<DetermineWhichCar>();
        testPoint = GameObject.Find("empty game object test position point");
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
            
            GameObject parentObjectWithVariedPrefabsInstance = Instantiate(parentObjectWithVariedPrefabsPublicHierarchyReference);
            parentObjectWithVariedPrefabsInstance.name += count + " Cass";

            //
            Transform waypointChildFromThisTransform = transform.GetChild(Random.Range(0, transform.childCount));



            //waypointChildFromThisTransform.GetComponent<WaypointNavigation>().currentWaypoint = waypointChildFromThisTransform.GetComponent<Waypoint>();
            //Debug.Log(obj.GetComponent<WaypointNavigation>().currentWaypoint);
            //notThisParentPrefabWithTransformOfManyVehicularChildren.transform.position = waypointChildFromThisTransform.position;
            //notThisParentPrefabWithTransformOfManyVehicularChildren.transform.position = waypointChildFromThisTransform.position;
            parentObjectWithVariedPrefabsInstance.transform.position = new Vector3(waypointChildFromThisTransform.position.x, 0, waypointChildFromThisTransform.position.z);

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
