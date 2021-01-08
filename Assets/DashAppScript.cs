using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashAppScript : MonoBehaviour
{
    public GameObject WayPointBoxRestaurant;
    public GameObject WayPointCustomer;

    public Transform[] restaurantSelection;
    public Transform[] customerLocations;

    public int restaurantSelected;
    public int customerLocation;
    public int customerName;

    public float OrderDuration = 3f;
    public float startingOrderDuration; //used for determining score
    public static float totalTimeRemaining;


    public bool orderSelected;

    public Text orderUI;
    public Text countDownTimer;

    float distanceBetweenTargetAndDestination; // used to calculate time

    public void Update()
    {
        OrderDuration -= Time.deltaTime;

        if (!GameManager.player1OrderDelivered)
        {
            totalTimeRemaining = (OrderDuration / distanceBetweenTargetAndDestination) * 2;
        }
        if (OrderDuration <= 0)
        {
            orderSelected = true;
        }

        if (GameManager.Player1OrderSelected)
        {
            //move waypoint boxes

            GameManager.Player1OrderSelected = false;

            distanceBetweenTargetAndDestination = (GameManager.player1Distance / 50);
            OrderDuration = distanceBetweenTargetAndDestination;

            // startingOrderDuration = distance between restaurant selected and customer selected (this does not change)
            // OrderDuration = distance between restaurant selected and customer selected

            //This is the UI to tell you the order -> Deliver "Product" from "Restaurant" to "CustomerName" at "CustomerLocation"

            orderUI.text = "Deliver " + GameManager.Player1CustomerItemOrdered + " from " + $"<color=green>{GameManager.Player1RestaurantName}</color>" + " to " + GameManager.Player1CustomerName + " at " + $"<color=yellow>{GameManager.Player1ApartmentName}</color>";
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
