using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneScript : MonoBehaviour
{
    public GameObject HomeScreen, OrdersMenu, GPSMenu, AlertsMenu, RatingsScreen;

    public void OrdersButtonPressed()
    {
        HomeScreen.SetActive(false);
        OrdersMenu.SetActive(true);
    }

    public void OrdersBack()
    {
        HomeScreen.SetActive(true);
        OrdersMenu.SetActive(false);
    }

    public void RatingsButtonPressed()
    {
        HomeScreen.SetActive(false);
        RatingsScreen.SetActive(true);
    }

    public void RatingsBack()
    {
        HomeScreen.SetActive(true);
        RatingsScreen.SetActive(false);
    }

    public void GPSButtonPressed()
    {
        HomeScreen.SetActive(false);
        GPSMenu.SetActive(true);
    }

    public void GPSButtonBack()
    {
        GPSMenu.SetActive(false);
        HomeScreen.SetActive(true);
    }
}
