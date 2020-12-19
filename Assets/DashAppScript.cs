using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashAppScript : MonoBehaviour
{
    public GameObject WayPointBoxRestaurant;
    public GameObject WayPointCustomer;
    public Transform[] restaurantSelection;
    public string[] restaurantName;
    public string[] productName;

    public Transform[] customerLocations;
    public string[] apartmentName;
    public string[] customerNames;

    public int restaurantSelected;
    public int customerLocation;
    public int customerName;

    public float OrderDuration = 3f;
    public float startingOrderDuration; //used for determining score
    bool orderSelected;

    public Text orderUI;
    public Text countDownTimer;

    public void Update()
    {
        OrderDuration -= Time.deltaTime;

        if (OrderDuration <= 0)
        {
            orderSelected = true;
        }

        if (orderSelected)
        {
            restaurantSelected = Random.Range(0, restaurantSelection.Length);
            customerName = Random.Range(0, customerNames.Length);
            customerLocation = Random.Range(0, customerLocations.Length);
            WayPointBoxRestaurant.transform.position = restaurantSelection[restaurantSelected].transform.position;
            WayPointCustomer.transform.position = customerLocations[restaurantSelected].transform.position;

            OrderDuration = 100; //remove this later, just for testing
            // startingOrderDuration = distance between restaurant selected and customer selected (this does not change)
            // OrderDuration = distance between restaurant selected and customer selected
            orderSelected = false;


            //This is the UI to tell you the order -> Deliver "Product" from "Restaurant" to "CustomerName" at "CustomerLocation"
            orderUI.text = "Deliver " + productName[restaurantSelected].ToString() + " from " + $"<color=green>{restaurantName[restaurantSelected].ToString()}</color>" + " to " + customerNames[customerName].ToString() + " at " + $"<color=yellow>{apartmentName[customerLocation].ToString()}</color>";
        }

        //UI
        if (OrderDuration > 0)
        {
            countDownTimer.text = OrderDuration.ToString("F2");
        }

        else
        {
            countDownTimer.text = "";
        }
    }
}
