using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneScript : MonoBehaviour
{
    public GameObject HomeScreen, OrdersMenu, GPSMenu, AlertsMenu, TBDMenu;

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
}
