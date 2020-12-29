using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //All this information is being fed from the PrefabOrder.cs and DashAppScript.cs

    public static string Player1RestaurantName, Player1ApartmentName, Player1CustomerName, Player1CustomerItemOrdered;
    public static Transform Player1RestaurantWayPoint, Player1ApartmentWayPoint;
    public static bool Player1OrderSelected;
    public static float player1Distance;

    public GameObject player1RestaurantWayPoint, player1ApartmentWayPoint;

    //some of these are in the ScooterDrive.cs
    public static bool player1OrderPickedUp;
    public static bool player1OrderDelivered;

    public static float player1ScoreOnOrder;
    public static float player1ScoreTotal;

    //This is the macro game timer
    public float TimeRemaining;
    public Text TimeUI;

    private void Start()
    {
        player1OrderPickedUp = false;
        player1OrderDelivered = false;
    }

    private void Update()
    {
        if (Player1RestaurantWayPoint != null && Player1ApartmentWayPoint != null)
        {
            player1RestaurantWayPoint.transform.position = Player1RestaurantWayPoint.transform.position;
            player1ApartmentWayPoint.transform.position = Player1ApartmentWayPoint.transform.position;
        }

        TimeRemainingInRound();
    }

    void TimeRemainingInRound()
    {
        TimeRemaining -= Time.deltaTime;

        float minutes = Mathf.FloorToInt(TimeRemaining / 60);
        float seconds = Mathf.FloorToInt(TimeRemaining % 60);

        TimeUI.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
