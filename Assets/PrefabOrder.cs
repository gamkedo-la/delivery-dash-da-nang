using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefabOrder : MonoBehaviour
{
    public string[] restaurantName;
    public string[] apartmentName;
    public string[] customerNames;

    public int restaurantSelected;
    public int customerLocation;
    public int customerName;

    public Text orderText;
    public Text orderState;

    bool orderHasBeenTaken;
    public Image orderCondition;

    public GameObject accept, decline;

    private void Start()
    {
        restaurantSelected = Random.Range(0, restaurantName.Length);
        customerName = Random.Range(0, customerNames.Length);
        customerLocation = Random.Range(0, apartmentName.Length);

        orderText.text = customerNames[customerName].ToString() + " ordered from " + restaurantName[restaurantSelected].ToString() + " to deliver to " + apartmentName[customerLocation].ToString();
    }

    public void OrderAccepted()
    {
        orderHasBeenTaken = true;
        accept.SetActive(false);
        decline.SetActive(true);
        orderCondition.color = Color.green;
        //display ui order for the player
    }

    public void OrderDeclined()
    {
        if (orderHasBeenTaken)
        {
            orderHasBeenTaken = false;
            accept.SetActive(true);
            decline.SetActive(false);
            orderCondition.color = Color.yellow;
        }
    }
}
