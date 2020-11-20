using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashIntoMe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            CarDrive CarDriveScript = collision.collider.gameObject.GetComponent<CarDrive>();
            CarDriveScript.RestartAtSpawn();
            Debug.Log("Player crashed!");
        }
        else
        {
            Debug.Log("I (" + gameObject.name + ") got bumped by " + collision.collider.gameObject.name);
        }
    }
}
