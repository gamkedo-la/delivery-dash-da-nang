using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideWithBuilding : MonoBehaviour
{

    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player1")
        {
            player.GetComponent<ScooterDrive>().currentSpeed = -2/10f;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Player1")
        {
            player.GetComponent<ScooterDrive>().currentSpeed = -2/10f;
        }
    }
}
