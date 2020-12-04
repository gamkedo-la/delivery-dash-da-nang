using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointScript : MonoBehaviour
{
    public bool listeningForPlayerSpeed = false;
    public bool waitingForPickup = false;
    public bool waitingForDropoff = false;
    public GameObject player;

    public GameObject snatchApp;
    public SnatchAppScript snatchAppScript;

    public Customer currentCustomerScript;

    public SFXScript sfxScript;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerScooter");

        snatchApp = GameObject.Find("SnatchApp");
        snatchAppScript = snatchApp.GetComponent<SnatchAppScript>();

        sfxScript = GameObject.Find("Main Camera").GetComponent<SFXScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("entered trigger zone");
        if (other.tag == "Player")
        {
            Debug.Log("player entered waypoint box");
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
                
                if (gameObject.activeSelf && snatchAppScript.SnatchAppStatus == "waiting for pickup")
                {
                    Debug.Log("pickup detected");
                    snatchAppScript.CurrentRestaurant.transform.Find("Waypoint Box").gameObject.SetActive(false);
                    currentCustomerScript = snatchAppScript.CurrentCustomer.GetComponent<Customer>();
                    var currentApartment = currentCustomerScript.home;            
                    var currentWaypointBox = currentApartment.gameObject.transform.Find("Waypoint Box");
                    currentWaypointBox.gameObject.SetActive(true);
                    listeningForPlayerSpeed = false;
                    sfxScript.pickupSFX.Play();
                    snatchAppScript.SnatchAppStatus = "waiting for dropoff";
                }
                else if (gameObject.activeSelf && snatchAppScript.SnatchAppStatus == "waiting for dropoff")
                {
                    Debug.Log("dropoff detected");
                    currentCustomerScript = snatchAppScript.CurrentCustomer.GetComponent<Customer>();
                    var currentApartment = currentCustomerScript.home;
                    var currentWaypointBox = currentApartment.gameObject.transform.Find("Waypoint Box");
                    currentWaypointBox.gameObject.SetActive(false);
                    sfxScript.chachingSFX.Play();
                    snatchAppScript.StartANewOrder();
                    listeningForPlayerSpeed = false;
                }
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
