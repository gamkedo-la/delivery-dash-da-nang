﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public string SnatchAppStatus;

    public Canvas DisplayMessageCanvas;
    public Text DisplayMessageTextBox;

    // Start is called before the first frame update
    void Start()
    {
        ListOfCustomers = GameObject.FindGameObjectsWithTag("Customer");
        ListOfRestaurants = GameObject.FindGameObjectsWithTag("Restaurant");

        startANewOrder();

        
    }

    public void startANewOrder()
    {
        Debug.Log("starting a new order");
        pickARandomRestaurant();
        pickARandomCustomer();
        setDeliveryMessages();
        activateRestaurantWaypointBox();

        SnatchAppStatus = "waiting for pickup";
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
        if (CurrentRestaurant.name == "Hannahs")
        {
            CurrentOrderMessage = CurrentCustomer.name + " wants " + currentCustomerScript.orderFromHannahs + " from " + CurrentRestaurant.name + ". Drop off at " + currentCustomerScript.home.name;
        }
        else if (CurrentRestaurant.name == "Fune Sushi")
        {
            CurrentOrderMessage = CurrentCustomer.name + " wants " + currentCustomerScript.orderFromFune + " from " + CurrentRestaurant.name + ". Drop off at " + currentCustomerScript.home.name;
        }
        Debug.Log("Current Order Message: " + CurrentOrderMessage);
        DisplayMessageTextBox.text = CurrentOrderMessage;
    }

    void activateRestaurantWaypointBox()
    {
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
