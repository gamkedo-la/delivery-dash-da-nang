using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideWithBuilding : MonoBehaviour
{

    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("building trigger enter recognized");
        Debug.Log(other.name);
        if (other.name == "Player1")
        {
            Debug.Log("other.name == Player1 reached");
            player.GetComponent<ScooterDrive>().currentSpeed = -2/10f;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("building trigger stay recognized");

        Debug.Log(other.name);

        if (other.name == "Player1")
        {
            Debug.Log("other.name == Player1 reached");

            player.GetComponent<ScooterDrive>().currentSpeed = -2/10f;
        }
    }

    
}
