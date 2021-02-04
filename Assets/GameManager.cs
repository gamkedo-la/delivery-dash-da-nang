using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreEntry : IComparable<ScoreEntry>
{
    public string name;
    public int score;

    public int CompareTo(ScoreEntry toCompare)
    {
        int ComparisonResult = score.CompareTo(toCompare.score);
        if (ComparisonResult == 0)
        {
            return name.CompareTo(toCompare.name);
        }
        return ComparisonResult;
    }
}

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

    public List<ScoreEntry> ScoreList = new List<ScoreEntry>();

    public Text[] rankUIText;

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

        ScoreEntry tempNew = new ScoreEntry();
        tempNew.name = "Player 1";
        tempNew.score = 28;
        ScoreList.Add(tempNew);

        tempNew = new ScoreEntry();
        tempNew.name = "Player 2";
        tempNew.score = 66;
        ScoreList.Add(tempNew);

        tempNew = new ScoreEntry();
        tempNew.name = "Player 3";
        tempNew.score = 28;
        ScoreList.Add(tempNew);

        tempNew = new ScoreEntry();
        tempNew.name = "Player 4";
        tempNew.score = 88;
        ScoreList.Add(tempNew);

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

            SortScores();

            for (int i = 0; i < ScoreList.Count; i++)
            {
                rankUIText[i].text = ScoreList[i].name + "     " + ScoreList[i].score.ToString("F0");
            }
        }
    }

    void SortScores()
    {
        ScoreList.Sort();
        ScoreList.Reverse();
    }
}
