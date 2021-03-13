using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject notThisParentPrefab;
    public int objectsToSpawn;

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
            if (gameObject.name == "CarSpawner")
            {
                Debug.Log("inside while loop of car spawner");
            }
            GameObject notThisParentPrefabWithTransformOfManyVehicularChildren = Instantiate(notThisParentPrefab);
            Debug.Log(notThisParentPrefabWithTransformOfManyVehicularChildren);
            Transform waypointChildFromThisTransform = transform.GetChild(Random.Range(0, transform.childCount - 1));
            if (gameObject.name == "CarSpawner")
            {
                Debug.Log(waypointChildFromThisTransform);
            }
            waypointChildFromThisTransform.GetComponent<WaypointNavigation>().currentWaypoint = waypointChildFromThisTransform.GetComponent<Waypoint>();
            //Debug.Log(obj.GetComponent<WaypointNavigation>().currentWaypoint);
            notThisParentPrefabWithTransformOfManyVehicularChildren.transform.position = waypointChildFromThisTransform.position;

            yield return new WaitForEndOfFrame();

            count++;
        }
    }
}
