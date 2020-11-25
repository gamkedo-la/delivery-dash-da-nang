using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointScript : MonoBehaviour
{
    public bool listeningForPlayerSpeed = false;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("scooter");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            listeningForPlayerSpeed = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (listeningForPlayerSpeed)
        {
            if (player.GetComponent<ScooterDrive>().currentSpeed == 0)
            {
                Debug.Log("delivery or drop off detected");
                listeningForPlayerSpeed = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
