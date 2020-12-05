using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsOnPlayer : MonoBehaviour
{
    Rigidbody rb;
    float RandX, RandY, RandZ;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            RandX = Random.Range(-360, 360);
            RandY = Random.Range(-360, 360);
            RandZ = Random.Range(-360, 360);

            float RandForceX = Random.Range(-ScooterDrive.playerCurrentSpeed / 4, ScooterDrive.playerCurrentSpeed / 4);
            float RandForceZ = Random.Range(-ScooterDrive.playerCurrentSpeed / 4, ScooterDrive.playerCurrentSpeed / 4);

            GetComponent<Rigidbody>().AddForce(new Vector3(RandForceX, ScooterDrive.playerCurrentSpeed, RandForceZ), ForceMode.Impulse);
            this.transform.rotation = Quaternion.Euler(RandX, RandY, RandZ);
        }
    }
}
