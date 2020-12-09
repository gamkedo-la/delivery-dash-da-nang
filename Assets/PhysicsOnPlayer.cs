using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsOnPlayer : MonoBehaviour
{
    Rigidbody rb;
    float RandX, RandY, RandZ;

    float RandForceZ;
    float RandForceX;

    bool hasBeenKnockedOver;

    public float lifetimeAfterKnockedOver = 10;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (hasBeenKnockedOver)
        {
            lifetimeAfterKnockedOver -= Time.deltaTime;
        }

        if (lifetimeAfterKnockedOver <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            RandX = Random.Range(-360, 360);
            RandY = Random.Range(270, 360);
            RandZ = Random.Range(-360, 360);

            if (ScooterDrive.isMovingNorth)
            {
                RandForceZ = Random.Range(-ScooterDrive.playerCurrentSpeed / 8,-ScooterDrive.playerCurrentSpeed / 4);
            }
            else if (ScooterDrive.isMovingSouth)
            {
                RandForceZ = Random.Range(ScooterDrive.playerCurrentSpeed / 4 , ScooterDrive.playerCurrentSpeed / 8);
            }

            if (ScooterDrive.isMovingEast)
            {
                RandForceX = Random.Range(-ScooterDrive.playerCurrentSpeed / 8,-ScooterDrive.playerCurrentSpeed / 4);
            }
            else if (ScooterDrive.isMovingWest)
            {
                RandForceX = Random.Range(ScooterDrive.playerCurrentSpeed / 4 ,ScooterDrive.playerCurrentSpeed / 8);
            }

            GetComponent<Rigidbody>().AddForce(new Vector3(RandForceX, ScooterDrive.playerCurrentSpeed, RandForceZ), ForceMode.Impulse);
            this.transform.rotation = Quaternion.Euler(RandX, RandY, RandZ);
            hasBeenKnockedOver = true;
        }
    }
}
