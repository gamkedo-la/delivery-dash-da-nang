using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRightTurnTaxi : MonoBehaviour
{
    public GameObject Taxi;
    //public NPCScooterDrive NPCScooterDriveScript;

    // Start is called before the first frame update
    void Start()
    {
        //NPCScooterDriveScript = NPCScooter.GetComponent<NPCScooterDrive>();
    }

    private void OnTriggerExit(Collider other)
    {
        other.GetComponent<TaxiDrive>().turnRight();
        //NPCScooterDriveScript.turnRight();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
