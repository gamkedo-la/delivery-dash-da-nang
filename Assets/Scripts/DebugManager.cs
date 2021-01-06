using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugManager : MonoBehaviour
{
    bool on = false;
    ScooterDrive scooterDriveScript;

    void HandleControlKeys()
    {
        if (Input.GetKeyUp(KeyCode.M))
        {
            toggleDebugManager();
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            scooterDriveScript.RestartAtSpawn();
        }
    }

    void toggleDebugManager()
    {
        if (!on)
        {
            on = true;
            Debug.Log("Debug Manager Toggled On");
        }
        else
        {
            on = false;
            Debug.Log("Debug Manager Toggled Off");
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        //scooterDriveScript = GameObject.Find("PlayerScooter").GetComponent<ScooterDrive>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleControlKeys();
    }
}
