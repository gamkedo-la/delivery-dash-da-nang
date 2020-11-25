using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnatchAppScript : MonoBehaviour
{
    //list of restaurants
    public GameObject HannahsWaypointBox;
    public GameObject FuneWaypointBox;

    public GameObject[] ListOfRestaurants;

    //list of Apartments
    public GameObject SeasandWaypointBox;
    public GameObject ChipsWaypointBox;

    public GameObject[] ListOfCustomers;

    //current app settings
    public GameObject CurrentRestaurant;
    public GameObject CurrentCustomer;

    public string CurrentOrderMessage;

    public Customer currentCustomerScript;

    // Start is called before the first frame update
    void Start()
    {
        ListOfCustomers = GameObject.FindGameObjectsWithTag("Customer");
        ListOfRestaurants = GameObject.FindGameObjectsWithTag("Restaurant");

        pickARandomRestaurant();
        pickARandomCustomer();
        setDeliveryMessages();
        activateRestaurantWaypointBox();
    }

    void pickARandomRestaurant()
    {
        var RandomIndex = Random.Range(0, ListOfRestaurants.Length);
        CurrentRestaurant = ListOfRestaurants[RandomIndex];
    }

    void pickARandomCustomer()
    {
        var RandomIndex = Random.Range(0, ListOfCustomers.Length);
        CurrentCustomer = ListOfCustomers[RandomIndex];
        currentCustomerScript = CurrentCustomer.GetComponent<Customer>();
    }

    void setDeliveryMessages()
    {
        Debug.Log("Current customer: " + CurrentCustomer.name);
        Debug.Log("Current restaurant: " + CurrentRestaurant.name);
        
        if (CurrentRestaurant.name == "Hannahs")
        {
            CurrentOrderMessage = CurrentCustomer.name + " wants " + currentCustomerScript.orderFromHannahs + " from " + CurrentRestaurant.name + ". Drop off at " + currentCustomerScript.home.name;
        }
        else if (CurrentRestaurant.name == "Fune Sushi")
        {
            CurrentOrderMessage = CurrentCustomer.name + " wants " + currentCustomerScript.orderFromFune + " from " + CurrentRestaurant.name + ". Drop off at " + currentCustomerScript.home.name;
        }
        Debug.Log("Current Order Message: " + CurrentOrderMessage);
    }

    void activateRestaurantWaypointBox()
    {
        Debug.Log("inside activate restaurant waypoint box   ");
        CurrentRestaurant.transform.Find("Waypoint Box").gameObject.SetActive(true);
    }

    void deactivateRestaurantWaypointBox()
    {
        CurrentRestaurant.transform.Find("Waypoint Box").gameObject.SetActive(false);
    }

    void activateCustomersHomeWaypointBox()
    {
        currentCustomerScript.home.transform.Find("Waypoint Box").gameObject.SetActive(true);
    }

    void deactivateCustomersHomeWaypointBox()
    {
        currentCustomerScript.home.transform.Find("Waypoint Box").gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
