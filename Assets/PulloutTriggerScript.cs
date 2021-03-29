using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulloutTriggerScript : MonoBehaviour
{
    public GameObject parentScooter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            parentScooter.transform.transform.Rotate(0, 180, 0);
            parentScooter.transform.GetComponent<NPCScooterFlatScreenDrive>().enabled = true;
        }
    }
}
