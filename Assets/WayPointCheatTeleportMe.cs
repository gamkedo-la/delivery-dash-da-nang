using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointCheatTeleportMe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.LogWarning("TeleportCheatScript is available. Remove before Release. Press 'J' to activate");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
           transform.position = WaypointCheat.instance.transform.position;
        }
    }
}
