using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerUTurn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<NPCScooterDrive>().turnAround();

        //NPCScooterDriveScript.turnRight();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
