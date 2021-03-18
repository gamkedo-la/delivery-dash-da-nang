﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeScreenScript : MonoBehaviour
{
    public List<GameObject> listOfButtons = new List<GameObject>();
    List<Image> listOfHighlights = new List<Image>();
    private GameObject OrdersButton;
    private GameObject GPSButton;
    private GameObject AlertsButton;
    private GameObject TBDButton;
    private GameObject CurrentRatingButton;

    private const int ordersIDX = 0;
    private const int gpsIDX = 1;
    private const int alertsIDX = 2;
    private const int ratingsIDX = 3;
    private const int currentRateIDX = 4;

    public bool dPadUpPressed = false;
    public bool dPadRightPressed = false;
    public bool dPadDownPressed = false;
    public bool dPadLeftPressed = false;

    private int currentActiveButtonIndex = 0;

    private GameObject phone;
    private GameObject homeScreen;

    public GameObject scooter;

    

    // Start is called before the first frame update
    void Start()
    {
        OrdersButton = listOfButtons[ordersIDX];
        GPSButton = listOfButtons[gpsIDX];
        AlertsButton = listOfButtons[alertsIDX];
        TBDButton = listOfButtons[ratingsIDX];
        CurrentRatingButton = listOfButtons[currentRateIDX];

        phone = GameObject.Find("Phone");
        homeScreen = GameObject.Find("HomeScreen");

        for (int i = 0; i < listOfButtons.Count; i++)
        {
            listOfHighlights.Add(listOfButtons[i].GetComponentInChildren<Highlight>().GetComponent<Image>());
        }

        UpdateHighlights();
    }

    void UpdateHighlights()
    {
        for (int i = 0; i < listOfHighlights.Count; i++)
        {
            listOfHighlights[i].gameObject.SetActive(i==currentActiveButtonIndex);
        }
    }

    public void handleGamepadUINavigation()
    {
        if (scooter.GetComponent<ScooterDrive>().phoneActive)
        {
            Debug.Log("Phone screen active reached");
            if (homeScreen.activeInHierarchy)
            {
                Debug.Log("Home Screen active reached");
            }
        }
        
    }

    public void handleHomeScreenGamepadNavigation()
    {
        if (OrdersButton.activeInHierarchy)
        {
            Debug.Log("yooooo");
            //if (dPadRightPressed)
            //{
            //    OrdersButton.transform.GetChild(1).SetActive(false);
            //}
        }
        //        GPSButton.transform.GetChild(1).SetActive(true);
        //    }

        //    else if (dPadPressedDown)
        //    {
        //        AlertsButton.transform.GetChild(1).SetActive(true);
        //        OrdersButton.transform.GetChild(1).SetActive(false);
        //    }

        //    else
        //    {
        //        dPadUpPressed = false;
        //        dPadRightPressed = false;
        //        dPadDownPressed = false;
        //        dpadLeftPressed = false;
        //        return;
        //    }
        //}

        //else if (GPSButton.transform.GetChild(1).active)
        //{
        //    if (dPadLeftPressed)
        //    {
        //        OrdersButton.transform.GetChild(1).SetActive(true);
        //        GPSButton.transform.GetChild(1).SetActive(false);
        //    }
        //    else if (dPadDownPressed)
        //    {
        //        GPSButton.transform.GetChild(1).SetActive(false);
        //        TBDButton.transform.GetChild(1).SetActive(true);
        //    }

        //    else
        //    {
        //        dPadUpPressed = false;
        //        dPadRightPressed = false;
        //        dPadDownPressed = false;
        //        dpadLeftPressed = false;
        //        return;
        //    }
        //}

        //else if (AlertsButton.transform.GetChild(1).active)
        //{
        //    if (dPadUpPressed)
        //    {
        //        OrdersButton.transform.GetChild(1).SetActive(true);
        //        AlertsButton.transform.GetChild(1).SetActive(false);
        //    }
        //    else if (dPadRightPressed)
        //    {

        //    }
        //}


        dPadUpPressed = false;
        dPadRightPressed = false;
        dPadDownPressed = false;
        dPadLeftPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dPadUpPressed)
        {
            switch (currentActiveButtonIndex)
            {
                case ordersIDX:
                    currentActiveButtonIndex = currentRateIDX;
                    break;
                case gpsIDX:
                    currentActiveButtonIndex = ratingsIDX;
                    break;
                case alertsIDX:
                    currentActiveButtonIndex = ordersIDX;
                    break;
                case currentRateIDX:
                    currentActiveButtonIndex = alertsIDX;
                    break;
                case ratingsIDX:
                    currentActiveButtonIndex = gpsIDX;
                    break;
            }
            UpdateHighlights();
            dPadUpPressed = false; 
        }
        if (dPadRightPressed)
        {
            dPadRightPressed = false;
        }
        if (dPadDownPressed)
        {
            dPadDownPressed = false;
        }
        if (dPadLeftPressed)
        {
            dPadLeftPressed = false;
        }
    }
}
