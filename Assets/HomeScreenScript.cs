using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

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

    public GameObject phoneCanvas;

    public PlayerInputHandler inputHandler;

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

        //     inputHandler.GetComponentInParent<PlayerInputHandler>();
        
        for (int i = 0; i < listOfButtons.Count; i++)
        {
            listOfHighlights.Add(listOfButtons[i].transform.GetChild(1).GetComponent<Image>());
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
        //if (scooter.GetComponent<ScooterDrive>().phoneActive)
        //{
        //    Debug.Log("Phone screen active reached");
        //    if (homeScreen.activeInHierarchy)
        //    {
        //        Debug.Log("Home Screen active reached");
        //    }
        //}
        
    }

    void Update()
    {
        if (dPadUpPressed)
        {
            //Debug.Log("dpad up pressed recognized in HomeScreenScript Update");
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
            switch (currentActiveButtonIndex)
            {
                case ordersIDX:
                    currentActiveButtonIndex = gpsIDX;
                    break;
                case gpsIDX:
                    currentActiveButtonIndex = ordersIDX;
                    break;
                case alertsIDX:
                    currentActiveButtonIndex = ratingsIDX;
                    break;
                case currentRateIDX:
                    currentActiveButtonIndex = currentRateIDX;
                    break;
                case ratingsIDX:
                    currentActiveButtonIndex = alertsIDX;
                    break;
            }
            UpdateHighlights();
            dPadRightPressed = false;
        }
        if (dPadDownPressed)
        {
            switch (currentActiveButtonIndex)
            {
                case ordersIDX:
                    currentActiveButtonIndex = alertsIDX;
                    break;
                case gpsIDX:
                    currentActiveButtonIndex = ratingsIDX;
                    break;
                case alertsIDX:
                    currentActiveButtonIndex = currentRateIDX;
                    break;
                case currentRateIDX:
                    currentActiveButtonIndex = ordersIDX;
                    break;
                case ratingsIDX:
                    currentActiveButtonIndex = gpsIDX;
                    break;
            }
            UpdateHighlights();
            dPadDownPressed = false;
        }
        if (dPadLeftPressed)
        {
            switch (currentActiveButtonIndex)
            {
                case ordersIDX:
                    currentActiveButtonIndex = gpsIDX;
                    break;
                case gpsIDX:
                    currentActiveButtonIndex = ordersIDX;
                    break;
                case alertsIDX:
                    currentActiveButtonIndex = ratingsIDX;
                    break;
                case currentRateIDX:
                    currentActiveButtonIndex = currentRateIDX;
                    break;
                case ratingsIDX:
                    currentActiveButtonIndex = alertsIDX;
                    break;
            }
            UpdateHighlights();
            dPadLeftPressed = false;
        }        
    }

    public void ButtonPressed()
    {
        if (currentActiveButtonIndex == gpsIDX)
        {
            phoneCanvas.GetComponentInParent<PhoneScript>().GPSButtonPressed();
        }

        if (currentActiveButtonIndex == ordersIDX)
        {
            phoneCanvas.GetComponentInParent<PhoneScript>().OrdersButtonPressed();
        }

        if (currentActiveButtonIndex == ratingsIDX)
        {
            phoneCanvas.GetComponentInParent<PhoneScript>().CustomerScoresPressed();
        }

        if (currentActiveButtonIndex == currentRateIDX)
        {
            phoneCanvas.GetComponentInParent<PhoneScript>().RatingsButtonPressed();
        }

        if (currentActiveButtonIndex == alertsIDX)
        {
            //phoneScript.THIS ISN'T WRITTEN YET();
        }
    }
}
