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
    public static string Player2RestaurantName, Player2ApartmentName, Player2CustomerName, Player2CustomerItemOrdered;
    public static string Player3RestaurantName, Player3ApartmentName, Player3CustomerName, Player3CustomerItemOrdered;
    public static string Player4RestaurantName, Player4ApartmentName, Player4CustomerName, Player4CustomerItemOrdered;
    public static Transform Player1RestaurantWayPoint, Player1ApartmentWayPoint;
    public static Transform Player2RestaurantWayPoint, Player2ApartmentWayPoint;
    public static Transform Player3RestaurantWayPoint, Player3ApartmentWayPoint;
    public static Transform Player4RestaurantWayPoint, Player4ApartmentWayPoint;
    public static bool Player1OrderSelected;
    public static float player1Distance;

    public static bool Player2OrderSelected;
    public static float player2Distance;

    public static bool Player3OrderSelected;
    public static float player3Distance;

    public static bool Player4OrderSelected;
    public static float player4Distance;

    public GameObject player1RestaurantWayPoint, player1ApartmentWayPoint;

    //some of these are in the ScooterDrive.cs
    public static bool player1OrderPickedUp;
    public static bool player1OrderDelivered;

    public static bool player2OrderPickedUp;
    public static bool player2OrderDelivered;

    public static bool player3OrderPickedUp;
    public static bool player3OrderDelivered;

    public static bool player4OrderPickedUp;
    public static bool player4OrderDelivered;

    public static int player1TotalOrders;
    public static float player1ScoreOnOrder;
    public static int player1ScoreTotal, player2ScoreTotal, player3ScoreTotal, player4ScoreTotal, enemy2ScoreTotal, enemy3ScoreTotal, enemy4ScoreTotal;

    //public float player1ScoreTotalDisplay, player2ScoreTotalDisplay, player3ScoreTotalDisplay, player4ScoreTotalDisplay, enemy2ScoreTotalDisplay, enemy3ScoreTotalDisplay, enemy4ScoreTotalDisplay;

    public List<float> playerScores = new List<float>();

    public List<ScoreEntry> ScoreList = new List<ScoreEntry>();

    public Text[] rankUIText;
    public Text[] rankUITextInGame;

    public Text[] rankUITextInGame2;
    public Text[] rankUITextInGame3;
    public Text[] rankUITextInGame4;

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

    public float LowQuality, MedQuality, HighQuality, UltraQuality;

    private void Start()
    {

        if (MainMenu.playerCount == 1)
        {
            Player1();
        }

        if (MainMenu.playerCount == 2)
        {
            Player2();
        }

        if (MainMenu.playerCount == 3)
        {
            Player3();
        }

        if (MainMenu.playerCount == 4)
        {
            Player4();
        }

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

        player2OrderPickedUp = false;
        player2OrderDelivered = false;

        player3OrderPickedUp = false;
        player3OrderDelivered = false;

        player4OrderPickedUp = false;
        player4OrderDelivered = false;
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
            //print(string.Format("{0:00}:{1:00}", minutes, seconds));

            SortScores();

            for (int i = 0; i < driverList.Count; i++)
            {
                rankUITextInGame[i].text = driverList[i].characterName + ":" + driverList[i].phoneScore.ToString("F0") ;
                rankUITextInGame2[i].text = driverList[i].characterName + ":" + driverList[i].phoneScore.ToString("F0");
                rankUITextInGame3[i].text = driverList[i].characterName + ":" + driverList[i].phoneScore.ToString("F0");
                rankUITextInGame4[i].text = driverList[i].characterName + ":" + driverList[i].phoneScore.ToString("F0");
            }
        }

        else
        {
            Player1();
            RoundOverObject.SetActive(true);

            SortScores();

            for (int i = 0; i < driverList.Count; i++)
            {
                rankUIText[i].text = driverList[i].characterName + ":" + driverList[i].phoneScore.ToString("F0") + " (" + driverList[i].score.ToString("F0") + "/" + driverList[i].totalOrders.ToString("F0") + ")";
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
            Player1();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            Player2();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            Player3();
        }


        if (Input.GetKeyDown(KeyCode.P))
        {
            Player4();
        }
    }

    void Player1()
    {
        Debug.Log("1 Player");
        player2.SetActive(false);
        player3.SetActive(false);
        player4.SetActive(false);

        player1Cam.rect = new Rect(0f, 0f, 1f, 1);

        player1Cam.farClipPlane = UltraQuality;
    }

    void Player2()
    {
        player2.SetActive(true);
        player3.SetActive(false);
        player4.SetActive(false);

        player1Cam.rect = new Rect(0f, 0f, 0.5f, 1);
        player2Cam.rect = new Rect(0.5f, 0f, 0.5f, 1);

        player1Cam.farClipPlane = HighQuality;
        player2Cam.farClipPlane = HighQuality;
    }

    void Player3()
    {
        player2.SetActive(true);
        player3.SetActive(true);
        player4.SetActive(false);

        player1Cam.rect = new Rect(0f, 0f, 0.5f, 1);
        player2Cam.rect = new Rect(0.5f, 0.5f, .5f, .5f);
        player3Cam.rect = new Rect(0.5f, 0f, .5f, .5f);

        player1Cam.farClipPlane = MedQuality;
        player2Cam.farClipPlane = MedQuality;
        player3Cam.farClipPlane = MedQuality;
    }

    void Player4()
    {
        player2.SetActive(true);
        player3.SetActive(true);
        player4.SetActive(true);

        player1Cam.rect = new Rect(0f, 0.5f, 0.5f, .5f);
        player2Cam.rect = new Rect(0.5f, 0.5f, .5f, .5f);
        player3Cam.rect = new Rect(0f, 0f, .5f, .5f);
        player4Cam.rect = new Rect(0.5f, 0f, .5f, .5f);

        player1Cam.farClipPlane = LowQuality;
        player2Cam.farClipPlane = LowQuality;
        player3Cam.farClipPlane = LowQuality;
        player4Cam.farClipPlane = LowQuality;
    }
}
