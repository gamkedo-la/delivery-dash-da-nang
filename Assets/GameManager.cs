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

    public static int player1TotalOrders;
    public static float player1ScoreOnOrder;
    public static int player1ScoreTotal, player2ScoreTotal, player3ScoreTotal, player4ScoreTotal, enemy2ScoreTotal, enemy3ScoreTotal, enemy4ScoreTotal;

    //public float player1ScoreTotalDisplay, player2ScoreTotalDisplay, player3ScoreTotalDisplay, player4ScoreTotalDisplay, enemy2ScoreTotalDisplay, enemy3ScoreTotalDisplay, enemy4ScoreTotalDisplay;

    public List<float> playerScores = new List<float>();

    public List<ScoreEntry> ScoreList = new List<ScoreEntry>();

    public Text[] rankUIText;
    public Text[] rankUITextInGame;

    public List<DeliveryDriver> driverList= new List<DeliveryDriver>(); 

    //This is the macro game timer
    public float TimeRemaining;
    public Text TimeUI;
    public GameObject RoundOverObject, restuarantWaypointBox, pointer, displayOrdersText;

    public bool easy, hard;
    public static bool Easy, Medium, Hard;

    public GameObject Enemy2, Enemy3, Enemy4;

    //Multiplayer
    public GameObject player2, player3, player4;
    public Camera player1Cam, player2Cam, player3Cam, player4Cam;

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

        for (int i = 0; i < driverList.Count; i++)
        {
            ScoreEntry tempNew = new ScoreEntry();
            tempNew.name = driverList[i].characterName;
            tempNew.score = driverList[i].score;
            ScoreList.Add(tempNew);
        }

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

        ToggleMultiplayer();
    }

    int entryForName(string nameToMatch)
    {
        for (int i = 0; i < ScoreList.Count; i++)
        {
            if (ScoreList[i].name == nameToMatch)
            {
                return i;
            }
        }
        Debug.Log("No Match Found in Score List for: " + nameToMatch);
        return -1;
    }

    void TimeRemainingInRound()
    {
        if (TimeRemaining >= 0)
        {
            TimeRemaining -= Time.deltaTime;

            float minutes = Mathf.FloorToInt(TimeRemaining / 60);
            float seconds = Mathf.FloorToInt(TimeRemaining % 60);

            TimeUI.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            SortScores();

            for (int i = 0; i < driverList.Count; i++)
            {
                rankUITextInGame[i].text = driverList[i].characterName + "     " + driverList[i].score.ToString("F0");
            }
        }

        else
        {

            RoundOverObject.SetActive(true);

            SortScores();

            for (int i = 0; i < driverList.Count; i++)
            {
                rankUIText[i].text = driverList[i].characterName + "     " + driverList[i].score.ToString("F0");
            }
        }
    }

    void SortScores()
    {
        driverList.Sort();
        driverList.Reverse();
    }

    void ToggleMultiplayer()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            Debug.Log("1 Player");
            player2.SetActive(false);
            player3.SetActive(false);
            player4.SetActive(false);

            player1Cam.rect = new Rect(0f, 0f, 1f, 1);

            player1Cam.farClipPlane = 500;
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            player2.SetActive(true);
            player3.SetActive(false);
            player4.SetActive(false);

            player1Cam.rect = new Rect(0f, 0f, 0.5f, 1);
            player2Cam.rect = new Rect(0.5f, 0f, 0.5f, 1);

            player1Cam.farClipPlane = 400;
            player2Cam.farClipPlane = 400;
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            player2.SetActive(true);
            player3.SetActive(true);
            player4.SetActive(false);

            player1Cam.rect = new Rect(0f, 0f, 0.5f, 1);
            player2Cam.rect = new Rect(0.5f, 0.5f, .5f, .5f);
            player3Cam.rect = new Rect(0.5f, 0f, .5f, .5f);

            player1Cam.farClipPlane = 300;
            player2Cam.farClipPlane = 300;
            player3Cam.farClipPlane = 300;
        }


        if (Input.GetKeyDown(KeyCode.P))
        {
            player2.SetActive(true);
            player3.SetActive(true);
            player4.SetActive(true);

            player1Cam.rect = new Rect(0f, 0.5f, 0.5f, .5f);
            player2Cam.rect = new Rect(0.5f, 0.5f, .5f, .5f);
            player3Cam.rect = new Rect(0f, 0f, .5f, .5f);
            player4Cam.rect = new Rect(0.5f, 0f, .5f, .5f);

            player1Cam.farClipPlane = 200;
            player2Cam.farClipPlane = 200;
            player3Cam.farClipPlane = 200;
            player4Cam.farClipPlane = 200;
        }
    }
}
