using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointScript : MonoBehaviour
{
    public bool listeningForPlayerSpeed = false;
    public GameObject player;

    public GameObject snatchApp;
    public SnatchAppScript snatchAppScript;

    public Customer currentCustomerScript;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("scooter");

        snatchApp = GameObject.Find("SnatchApp");
        snatchAppScript = snatchApp.GetComponent<SnatchAppScript>();
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
                if (snatchAppScript.CurrentRestaurant.transform.Find("Waypoint Box").gameObject.activeSelf)
                {
                    snatchAppScript.CurrentRestaurant.transform.Find("Waypoint Box").gameObject.SetActive(false);
                    currentCustomerScript = snatchAppScript.CurrentCustomer.GetComponent<Customer>();
                    var currentApartment = currentCustomerScript.home;
                    Debug.Log("currentApartment: " + currentApartment.name);
                    var currentWaypointBox = currentApartment.gameObject.transform.Find("Waypoint Box");
                    Debug.Log("currentWaypointBox: " + currentWaypointBox);
                    currentWaypointBox.gameObject.SetActive(true);
                }
                else
                {
                    currentCustomerScript = snatchAppScript.CurrentCustomer.GetComponent<Customer>();
                    var currentApartment = currentCustomerScript.home;
                    var currentWaypointBox = currentApartment.gameObject.transform.Find("Waypoint Box");
                    currentWaypointBox.gameObject.SetActive(false);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
