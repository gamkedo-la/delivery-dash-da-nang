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

    public float player1ScoreTotalDisplay, player2ScoreTotalDisplay, player3ScoreTotalDisplay, player4ScoreTotalDisplay, enemy2ScoreTotalDisplay, enemy3ScoreTotalDisplay, enemy4ScoreTotalDisplay;

    public List<float> playerScores = new List<float>(); 

    public Text first, second, third, fourth, fifth, sixth, seventh;
    public string[] playerNames; 

    //This is the macro game timer
    public float TimeRemaining;
    public Text TimeUI;
    public GameObject RoundOverObject, restuarantWaypointBox, pointer, displayOrdersText;

    public bool easy, hard;
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
        player1ScoreTotal = Random.Range(0, 100);
        player2ScoreTotal = Random.Range(0,100);
        player3ScoreTotal = Random.Range(0,100);
        player4ScoreTotal = Random.Range(0,100);
        enemy2ScoreTotal = Random.Range(0, 100);
        enemy3ScoreTotal = Random.Range(0, 100);
        enemy4ScoreTotal = Random.Range(0, 100);

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

            first.text = playerNames[0] + "     " + playerScores[0].ToString("F0");
            second.text = playerNames[1] + "     " + playerScores[1].ToString("F0");
            third.text = playerNames[2] + "     " + playerScores[2].ToString("F0");
            fourth.text = playerNames[3] + "     " + playerScores[3].ToString("F0");
            fifth.text = playerNames[4] + "     " + playerScores[4].ToString("F0");
            sixth.text = playerNames[5]+ "     " + playerScores[5].ToString("F0");
            seventh.text = playerNames[6] + "     " + playerScores[6].ToString("F0");




          //  SortScores();
            print(playerScores[0]);
        }
    }

    void SortScores()
    {

        playerScores.Sort();
        playerScores.Reverse();
    }
}
