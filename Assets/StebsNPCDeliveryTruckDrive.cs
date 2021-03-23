using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StebsNPCDeliveryTruckDrive : MonoBehaviour
{
    public float truckSpeed = 0.66f;
    // Update is called once per frame
    void Update()
    {
        Vector3 distanceToTranslate = new Vector3(truckSpeed, 0, 0);
        transform.Translate(distanceToTranslate);
    }
}
