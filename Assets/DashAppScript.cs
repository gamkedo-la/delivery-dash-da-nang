using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashAppScript : MonoBehaviour
{
    public GameObject WayPointBox;
    public Transform[] restaurantSelection;
    public string[] restaurantName;
    public string[] productName;
    public int restaurantSelected;

    public float OrderDuration = 3f;
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
            WayPointBox.transform.position = restaurantSelection[restaurantSelected].transform.position;
            print(restaurantSelection[restaurantSelected]);
            OrderDuration = 100; //remove this later, just for testing
            // OrderDuration = distance between restaurant selected and customer selected
            orderSelected = false;
            orderUI.text = "Deliver " + productName[restaurantSelected].ToString() + " from " + $"<color=green>{restaurantName[restaurantSelected].ToString()}</color>" + " to " + $"<color=yellow>{"THIS WILL BE CUSTOMER NAME"}</color>";
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
