using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRightTurn : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RightTurnVehicle")
        {
            other.transform.Rotate(0, 90, 0);
        }
    }
    



    
}
