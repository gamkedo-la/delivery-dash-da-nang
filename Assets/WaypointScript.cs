using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointScript : MonoBehaviour
{
    public bool listeningForPlayerSpeed = false;
    public bool waitingForPickup = false;
    public bool waitingForDropoff = false;
    public GameObject player;

    public GameObject DashApp;
    public DashAppScript dashAppScript;

    public Customer currentCustomerScript;

    public SFXScript sfxScript;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerScooter");

        DashApp = GameObject.Find("DashApp");
        dashAppScript = DashApp.GetComponent<DashAppScript>();

        sfxScript = GameObject.Find("Main Camera").GetComponent<SFXScript>();
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
                if (gameObject.activeSelf && dashAppScript.DashAppStatus == "waiting for pickup")
                {
                    dashAppScript.CurrentRestaurant.transform.Find("Waypoint Box").gameObject.SetActive(false);
                    currentCustomerScript = dashAppScript.CurrentCustomer.GetComponent<Customer>();
                    var currentApartment = currentCustomerScript.home;            
                    var currentWaypointBox = currentApartment.gameObject.transform.Find("Waypoint Box");
                    currentWaypointBox.gameObject.SetActive(true);
                    listeningForPlayerSpeed = false;
                    sfxScript.pickupSFX.Play();
                    dashAppScript.DashAppStatus = "waiting for dropoff";
                }
                else if (gameObject.activeSelf && dashAppScript.DashAppStatus == "waiting for dropoff")
                {
                    currentCustomerScript = dashAppScript.CurrentCustomer.GetComponent<Customer>();
                    var currentApartment = currentCustomerScript.home;
                    var currentWaypointBox = currentApartment.gameObject.transform.Find("Waypoint Box");
                    currentWaypointBox.gameObject.SetActive(false);
                    sfxScript.chachingSFX.Play();
                    dashAppScript.StartANewOrder();
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
