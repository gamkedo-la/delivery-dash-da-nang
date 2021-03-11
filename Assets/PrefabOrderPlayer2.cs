﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PrefabOrderPlayer2 : MonoBehaviour
{
    public string[] restaurantName;
    public string[] apartmentName;
    public string[] customerNames;
    public string[] orderedItems;

    Transform[] restaurantLocations;
    Transform[] apartmentLocations;

    Transform playerLocation;

    public int restaurantSelected;
    public int customerLocation;
    public int customerName;

    public Text orderText;
    public Text orderState;

    public static bool orderHasBeenTaken;
    public Image orderCondition;

    public GameObject accept, decline, displayOrdersText, gameManager;

    GameObject player2WayPoint, pointer, pointerCube;
    Transform Player2RestaurantTransform, Player2ApartmentTransform;

    PointToObjective pointToObjectiveScript;
    private GraphPathfinding gpsScript;
    private GraphNode restaurantNode;

    private AudioClip phoneButtonPressedAudioClip;
    private PhoneScript phoneScript;

    public float minOrderTime = 35;

    private void Start()
    {
        phoneScript = GameObject.Find("Canvas - PlayerPhone2").GetComponent<PhoneScript>();
        phoneButtonPressedAudioClip = phoneScript.phoneButtonPressedAudioClip;

        gameManager = GameObject.Find("GameManager");
        //Debug.Log(gameManager);
        GameObject masterKeyWaypoint = GameObject.Find("Player1Restaurant");

        if (masterKeyWaypoint == null)
        {
            Debug.Log("masterKeyWaypoint not found, bailing on prefab orders");
            this.enabled = false;
            return;
        }

        Player2RestaurantTransform = GameObject.Find("Player2Restaurant").transform;
        Player2ApartmentTransform = GameObject.Find("Player2Apartment").transform;

        restaurantLocations = new Transform[3];

        restaurantLocations[0] = GameObject.Find("HannahsWayPoint").transform;
        // restaurantLocations[0].position = new Vector3(1450f, 2.1f, 250.9f);

        restaurantLocations[1] = GameObject.Find("RamenWayPoint").transform;

        // restaurantLocations[1].position = new Vector3(1450f, 2.1f, 250.9f);

        restaurantLocations[2] = GameObject.Find("SushiWayPoint").transform;

        // restaurantLocations[2].position = new Vector3(1450f, 2.1f, 250.9f);


        apartmentLocations = new Transform[2];

        apartmentLocations[0] = GameObject.Find("ChipsWayPoint").transform;
        apartmentLocations[1] = GameObject.Find("SeasandWayPoint").transform;

        // apartmentLocations[0].position = new Vector3(1550f, 2.1f, 250.9f);
        // apartmentLocations[1].position = new Vector3(1550f, 2.1f, 250.9f);
        //  apartmentLocations[2] = GameObject.Find("28 Apartment Waypoint").transform;
        //  apartmentLocations[3] = GameObject.Find("Halina WayPoint").transform;

        player2WayPoint = GameObject.Find("WayPointBox - Restaurant2");
        // player1ApartmentWayPoint = GameObject.Find("WayPointBox - Customer");

        restaurantSelected = Random.Range(0, restaurantName.Length);
        customerName = Random.Range(0, customerNames.Length);
        customerLocation = Random.Range(0, apartmentName.Length);

        gpsScript = FindObjectOfType<GraphPathfinding>();

        orderText.text = customerNames[customerName].ToString() + " ordered " + orderedItems[restaurantSelected] + " from " + restaurantName[restaurantSelected].ToString() + " to deliver to " + apartmentName[customerLocation].ToString();
    }

    public void OrderAccepted()
    {
        AudioManager.Instance.PlaySoundSFX(phoneButtonPressedAudioClip, gameObject, volume: 0.5f);

        orderHasBeenTaken = true;
        orderCondition.color = Color.green;

        pointer = GameObject.Find("Canvas - Display Orders2").transform.GetChild(2).gameObject;
        pointer.SetActive(true);
        pointToObjectiveScript = pointer.GetComponent<PointToObjective>();

        pointerCube = pointer.transform.GetChild(2).gameObject;
        pointerCube.SetActive(false);
        //    pointToObjectiveScript.customerOrder = gameObject;
        //Debug.Log("restaurant name: " + restaurantName);



        GameManager.Player2OrderSelected = true;
        //print(GameManager.Player1OrderSelected);

        GameManager.Player2CustomerItemOrdered = orderedItems[restaurantSelected].ToString();
        GameManager.Player2ApartmentName = apartmentName[customerLocation].ToString();
        GameManager.Player2CustomerName = customerNames[customerName].ToString();
        GameManager.Player2RestaurantName = restaurantName[restaurantSelected].ToString();

        Player2RestaurantTransform.transform.position = restaurantLocations[restaurantSelected].transform.position;
        Player2ApartmentTransform.transform.position = apartmentLocations[customerLocation].transform.position;

        float dist = Vector3.Distance(Player2RestaurantTransform.position, Player2ApartmentTransform.position) / 5;

        if (dist < minOrderTime)
        {
            RestaurantWaypoint2.player2TimeScore = minOrderTime;
            RestaurantWaypoint2.player2TimeScoreMax = minOrderTime;
        }
        else
        {
            RestaurantWaypoint2.player2TimeScore = dist;
            RestaurantWaypoint2.player2TimeScoreMax = dist;
        }

        player2WayPoint.transform.position = Player2RestaurantTransform.transform.position;

        RestaurantWaypoint2.player2OrderPickedUp = false;
        RestaurantWaypoint2.player2OrderDelivered = false;

        playerLocation = FindObjectOfType<ScooterDrive>().transform;
        restaurantNode = restaurantLocations[restaurantSelected].GetComponent<GraphNode>();
        gpsScript.FindPath(gpsScript.FindNearestNode(playerLocation), restaurantNode);

        StartCoroutine(Waiting());
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
}
