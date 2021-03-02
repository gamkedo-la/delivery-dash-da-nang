using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeScreenScript : MonoBehaviour
{
    public List<GameObject> listOfButtons = new List<GameObject>();
    private GameObject OrdersButton;
    private GameObject GPSButton;
    private GameObject AlertsButton;
    private GameObject TBDButton;
    private GameObject CurrentRatingButton;

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
        OrdersButton = listOfButtons[0];
        GPSButton = listOfButtons[1];
        AlertsButton = listOfButtons[2];
        TBDButton = listOfButtons[3];
        CurrentRatingButton = listOfButtons[4];

        phone = GameObject.Find("Phone");
        homeScreen = GameObject.Find("HomeScreen");

    }

    public void handleGamepadUINavigation()
    {
        if (scooter.GetComponent<ScooterDrive>().phoneActive)
        {
            Debug.Log("Phone screen active reached");
            if (homeScreen.active)
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

    }
    /*
     * 

    

    

    

    

    
     */

}
