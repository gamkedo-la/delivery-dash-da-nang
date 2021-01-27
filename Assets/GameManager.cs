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
    public static float player1ScoreTotal, player2ScoreTotal, player3ScoreTotal, player4ScoreTotal, enemy2ScoreTotal, enemy3ScoreTotal, enemy4ScoreTotal;

    public List<float> playerScores = new List<float>(); 

    public Text player1ScoreText, player2ScoreText, player3ScoreText, player4ScoreText, enemy2ScoreText, enemy3ScoreText, enemy4ScoreText;

    //This is the macro game timer
    public float TimeRemaining;
    public Text TimeUI;
    public GameObject RoundOverObject, restuarantWaypointBox, pointer, displayOrdersText;

    public bool easy, medium, hard;
    public static bool Easy, Medium, Hard;

    public GameObject Enemy2, Enemy3, Enemy4;

    private void Start()
    {
        if (easy)
        {
            Easy = true;
            Medium = false;
            Hard = false;
        }

        if (medium)
        {
            Easy = false;
            Medium = true;
            Hard = false;

            Enemy2.GetComponent<EnemyAI>().enabled = false;
            Enemy3.GetComponent<EnemyAI>().enabled = false;
            Enemy4.GetComponent<EnemyAI>().enabled = false;
        }

        if (hard)
        {
            Easy = false;
            Medium = false;
            Hard = true;

            Enemy2.GetComponent<EnemyAI>().enabled = false;
            Enemy3.GetComponent<EnemyAI>().enabled = false;
            Enemy4.GetComponent<EnemyAI>().enabled = false;
        }


        //This is for testing, remove later
        //  player1ScoreTotal = Random.Range(0, 100);
        player2ScoreTotal = Random.Range(0,1);
        player3ScoreTotal = Random.Range(0,1);
        player4ScoreTotal = Random.Range(0,1);

        playerScores.Add(player1ScoreTotal);
        playerScores.Add(player2ScoreTotal);
        playerScores.Add(player3ScoreTotal);
        playerScores.Add(player4ScoreTotal);
        playerScores.Add(enemy2ScoreTotal);
        playerScores.Add(enemy3ScoreTotal);
        playerScores.Add(enemy4ScoreTotal);


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
        if (TimeRemaining >= 0)
        {
            TimeRemaining -= Time.deltaTime;

            float minutes = Mathf.FloorToInt(TimeRemaining / 60);
            float seconds = Mathf.FloorToInt(TimeRemaining % 60);

            TimeUI.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        else
        {
            RoundOverObject.SetActive(true);
            playerScores.Sort();
            playerScores.Reverse();
            player1ScoreText.text = player1ScoreText.name.ToString() + "     " + playerScores[0].ToString("F0");
            player2ScoreText.text = player2ScoreText.name.ToString() + "     " + playerScores[1].ToString("F0");
            player3ScoreText.text = player3ScoreText.name.ToString() + "     " + playerScores[2].ToString("F0");
            player4ScoreText.text = player4ScoreText.name.ToString() + "     " + playerScores[3].ToString("F0");
            enemy2ScoreText.text = enemy2ScoreText.name.ToString() + "     " + playerScores[4].ToString("F0");
            enemy3ScoreText.text = enemy3ScoreText.name.ToString() + "     " + playerScores[5].ToString("F0");
            enemy4ScoreText.text = enemy4ScoreText.name.ToString() + "     " + playerScores[6].ToString("F0");

        }
    }
}
