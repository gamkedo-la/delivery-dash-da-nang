using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugManager : MonoBehaviour
{
    bool on = false;
    CarDrive carDriveScript;

    void HandleControlKeys()
    {
        if (Input.GetKeyUp(KeyCode.D))
        {
            toggleDebugManager();
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            carDriveScript.RestartAtSpawn();
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
            carDriveScript = GameObject.Find("scooter").GetComponent<CarDrive>();
        Debug.Log("anything");
        }

        // Update is called once per frame
        void Update()
        {
            HandleControlKeys();
        }
    }
