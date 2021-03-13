using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCVehicleNavigator : MonoBehaviour
{

    CarController npcVehicleController;
    public NPCVehicleWaypoint currentNPCVehicleWaypoint;

    private void wake()
    {
        npcVehicleController = GetComponent<CarController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        npcVehicleController.SetDestination(currentNPCVehicleWaypoint.GetPosition());
    }

    // Update is called once per frame
    void Update()
    {
        if (npcVehicleController.reachedDestination)
        {
            
            currentNPCVehicleWaypoint = currentNPCVehicleWaypoint.nextWaypoint;
            npcVehicleController.SetDestination(currentNPCVehicleWaypoint.GetPosition());
        }    
    }
}
