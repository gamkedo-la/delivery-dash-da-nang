using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRightTurn : MonoBehaviour
{
    public GameObject NPCScooter;
    //public NPCScooterDrive NPCScooterDriveScript;

    // Start is called before the first frame update
    void Start()
    {
        //NPCScooterDriveScript = NPCScooter.GetComponent<NPCScooterDrive>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("anything");
    }
    private void OnTriggerExit(Collider other)
    {
        other.GetComponent<NPCScooterDrive>().turnRight();
        Debug.Log("detected right turn");
        //NPCScooterDriveScript.turnRight();
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
