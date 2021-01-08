using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefabOrder : MonoBehaviour
{
    public string[] restaurantName;
    public string[] apartmentName;
    public string[] customerNames;
    public string[] orderedItems;

    Transform[] restaurantLocations;
    Transform[] apartmentLocations;

    public int restaurantSelected;
    public int customerLocation;
    public int customerName;

    public Text orderText;
    public Text orderState;

    public static bool orderHasBeenTaken;
    public Image orderCondition;

    public GameObject accept, decline, displayOrdersText, gameManager;

    GameObject player1WayPoint, pointer;
    Transform Player1RestaurantTransform, Player1ApartmentTransform;

    PointToObjective pointToObjectiveScript;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        //Debug.Log(gameManager);
        Player1RestaurantTransform = GameObject.Find("Player1Restaurant").transform;
        Player1ApartmentTransform = GameObject.Find("Player1Apartment").transform;

        restaurantLocations = new Transform[3];

        restaurantLocations[0] = GameObject.Find("HannahsWayPoint").transform;
        restaurantLocations[1] = GameObject.Find("RamenWayPoint").transform;
        restaurantLocations[2] = GameObject.Find("SushiWayPoint").transform;

        apartmentLocations = new Transform[4];

        apartmentLocations[0] = GameObject.Find("ChipsWayPoint").transform;
        apartmentLocations[1] = GameObject.Find("SeasandWayPoint").transform;
        apartmentLocations[2] = GameObject.Find("28 Apartment Waypoint").transform;
        apartmentLocations[3] = GameObject.Find("Halina WayPoint").transform;

        player1WayPoint = GameObject.Find("WayPointBox - Restaurant");
       // player1ApartmentWayPoint = GameObject.Find("WayPointBox - Customer");

        restaurantSelected = Random.Range(0, restaurantName.Length);
        customerName = Random.Range(0, customerNames.Length);
        customerLocation = Random.Range(0, apartmentName.Length);

        orderText.text = customerNames[customerName].ToString() + " ordered " + orderedItems[restaurantSelected] + " from " + restaurantName[restaurantSelected].ToString() + " to deliver to " + apartmentName[customerLocation].ToString();
    }

    public void OrderAccepted()
    {
        orderHasBeenTaken = true;
        orderCondition.color = Color.green;

        pointer = GameObject.Find("Canvas - Display Orders").transform.GetChild(2).gameObject;
        pointer.SetActive(true);
        pointToObjectiveScript = pointer.GetComponent<PointToObjective>();
    //    pointToObjectiveScript.customerOrder = gameObject;
        //Debug.Log("restaurant name: " + restaurantName);

        

        GameManager.Player1OrderSelected = true;
        //print(GameManager.Player1OrderSelected);

        GameManager.Player1CustomerItemOrdered = orderedItems[restaurantSelected].ToString();
        GameManager.Player1ApartmentName = apartmentName[customerLocation].ToString();
        GameManager.Player1CustomerName = customerNames[customerName].ToString();
        GameManager.Player1RestaurantName = restaurantName[restaurantSelected].ToString();

        Player1RestaurantTransform.transform.position = restaurantLocations[restaurantSelected].transform.position;
        Player1ApartmentTransform.transform.position = apartmentLocations[customerLocation].transform.position;

        float dist = Vector3.Distance(Player1RestaurantTransform.position, Player1ApartmentTransform.position) / 50;
        RestaurantWaypointTriggerEnter.player1TimeScore = dist;
        RestaurantWaypointTriggerEnter.player1TimeScoreMax = dist;

        player1WayPoint.transform.position = Player1RestaurantTransform.transform.position;

        RestaurantWaypointTriggerEnter.player1OrderPickedUp = false;
        RestaurantWaypointTriggerEnter.player1OrderDelivered = false;

        StartCoroutine(Waiting());
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(.5f);
        Destroy(this.gameObject);
    }
}
