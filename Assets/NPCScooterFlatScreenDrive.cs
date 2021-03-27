using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScooterFlatScreenDrive : MonoBehaviour
{
    public float flatScreenScooterSpeed = 1f;
    // Update is called once per frame
    void Update()
    {
        Vector3 distanceToTranslate = new Vector3(0, 0, flatScreenScooterSpeed);
        transform.Translate(distanceToTranslate);
    }
}
