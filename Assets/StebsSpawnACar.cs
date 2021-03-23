using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StebsSpawnACar : MonoBehaviour
{

    public GameObject waypointHolder;
    private Transform startingWaypoint;
    public GameObject anyVisibleObject;
    // Start is called before the first frame update
    void Start()
    {
        //int startingWaypointChildCountIndex = Random.Range(0, waypointHolder.transform.childCount);
        //startingWaypoint = waypointHolder.transform.GetChild(startingWaypointChildCountIndex);
        startingWaypoint = waypointHolder.transform.GetChild(0);
        //Debug.Log("startingWaypoint: " + startingWaypoint);
        this.transform.position = startingWaypoint.position;
        //transform.position.y = 0.0f;
        //Instantiate(this.anyVisibleObject);
        //this.anyVisibleObject.transform.position = startingWaypoint.position;
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
