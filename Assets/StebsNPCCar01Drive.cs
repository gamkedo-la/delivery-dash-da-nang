using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StebsNPCCar01Drive : MonoBehaviour
{
    public float carSpeed = 1f;
    // Update is called once per frame
    void Update()
    {
        Vector3 distanceToTranslate = new Vector3(carSpeed, 0, 0);
        transform.Translate(distanceToTranslate);
    }
}
