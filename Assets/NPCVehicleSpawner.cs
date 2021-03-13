using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCVehicleSpawner : MonoBehaviour
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
        while (count < objectsToSpawn)
        {

            GameObject notThisParentPrefabWithTransformOfManyVehicularChildren = Instantiate(notThisParentPrefab);
            //
            Transform waypointChildFromThisTransform = transform.GetChild(Random.Range(0, transform.childCount - 1));

            if (gameObject.name == "NgoThiSiVehicleWaypoints")
            {
                Debug.Log("inside car spawner while loop waypointChildFromThisTransform");
                Debug.Log(notThisParentPrefabWithTransformOfManyVehicularChildren);
                Debug.Log(waypointChildFromThisTransform);
            }
            //waypointChildFromThisTransform.GetComponent<NPCVehicleWaypointNavigation>().currentWaypoint = waypointChildFromThisTransform.GetComponent<NPCVehicleWaypoint>();
            //Debug.Log(obj.GetComponent<WaypointNavigation>().currentWaypoint);
            notThisParentPrefabWithTransformOfManyVehicularChildren.transform.position = waypointChildFromThisTransform.position;

            yield return new WaitForEndOfFrame();

            count++;
        }
    }
}
