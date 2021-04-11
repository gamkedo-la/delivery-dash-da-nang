using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestaurantWaypointTriggerEnter : MonoBehaviour
{
    public AudioSource orderPickedUpSFX, chachingSFX;

    public static bool player1OrderPickedUp;
    public static bool player1OrderDelivered;

    public static float player1TimeScore, player1TimeScoreMax;

    public GameObject pointer;
    public Text timer;
    public GameObject food, player;

    public Text orders; // UI element that displays orders on the top of the list

    float finalScore;

    private GraphPathfinding gpsScript;
    private GraphNode customerNode;
    private GraphNode nodeNearestToPlayer;

    private DeliveryDriver receivedDriver;

    private void Start()
    {
        gpsScript = FindObjectOfType<GraphPathfinding>();
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "Player" && other.name == "Player1")
        {
            receivedDriver = other.GetComponent<DeliveryDriver>();
            if (PrefabOrder.orderHasBeenTaken)
            {
                if (player1OrderPickedUp && !player1OrderDelivered && player.GetComponent<ScooterDrive>().currentSpeed == 0)
                {
                    player1OrderDelivered = true;
                    chachingSFX.Play();
                    GameManager.Player1OrderSelected = false;
                    gpsScript.ClearPath();
                }

                if (!player1OrderPickedUp && player.GetComponent<ScooterDrive>().currentSpeed == 0)
                {
                    player1OrderPickedUp = true;
                    food.SetActive(true);

                    orderPickedUpSFX.Play();
                    this.gameObject.transform.position = GameObject.Find("Player1Apartment").transform.position;
                    orders.text = "Deliver " + GameManager.Player1CustomerItemOrdered + " to " + GameManager.Player1CustomerName + " at " + $"<color=yellow>{GameManager.Player1ApartmentName}</color>";
                    customerNode = gpsScript.FindNearestNode(gameObject.transform);
                    nodeNearestToPlayer = gpsScript.FindNearestNode(player.transform);
                    gpsScript.FindPath(nodeNearestToPlayer, customerNode);
                }
            }
        }

    }

    private void Update()
    {
        if (PrefabOrder.orderHasBeenTaken && player1OrderPickedUp && player1OrderDelivered)
        {
            player.GetComponent<ScooterDrive>().AssignStars();
            float score = (player1TimeScore / player1TimeScoreMax) * 100;
            float score2 = FoodHealth.currentHealth1;
            finalScore = (score + score2) / 2;
            //
            if (receivedDriver != null)
            {
                receivedDriver.PlayerIncreaseOrderTotal((int)finalScore);
            }
            else
            {                
                Debug.LogWarning("The driver can't be found"); 
            }

            DisplayScore();
            PrefabOrder.orderHasBeenTaken = false;
            player1OrderPickedUp = false;
            player1OrderDelivered = false;
            food.SetActive(false);
            pointer.SetActive(false);
            //Just getting the box out of the way
            this.transform.position = new Vector3(-10000, -10000, -10000);
            orders.text = "Order Completed";
            timer.text = "";
            StartCoroutine(Waiting());
        }

        if (PrefabOrder.orderHasBeenTaken)
        {
            player1TimeScore -= Time.deltaTime;
            //if (player1TimeScore < 10f)
            //{
            //    player1TimeScore = 10f;
            //}
            timer.text = player1TimeScore.ToString("F2");
        }

        if (player1TimeScore < 0)
        {
            //Order failed on Time
            player.GetComponent<ScooterDrive>().AssignStars();
            if (receivedDriver != null)
            {
                receivedDriver.PlayerIncreaseOrderTotal((int)finalScore);
            }
            else
            {
                Debug.LogWarning("The driver can't be found");
            }

            orders.text = "Order Not Delivered in Time. Transaction Cancelled.";
            float score = 0;
            timer.text = score.ToString("F2") + "%";
            PrefabOrder.orderHasBeenTaken = false;
            Debug.Log("PrefabOrderPlayer1.orderHasBeenTaken1: " + PrefabOrder.orderHasBeenTaken);
            GameManager.Player1OrderSelected = false;
            player1OrderPickedUp = false;
            player1OrderDelivered = false;
            food.SetActive(false);
            this.transform.position = new Vector3(-10000, -10000, -10000);
            player1TimeScore = 0;
            pointer.SetActive(false);
            timer.text = "";
            StartCoroutine(Waiting());

        }

        if (FoodHealth.currentHealth1 < 0)
        {
            //Order failed on Time
            player.GetComponent<ScooterDrive>().AssignStars();
            if (receivedDriver != null)
            {
                receivedDriver.PlayerIncreaseOrderTotal((int)finalScore);
            }
            else
            {
                Debug.LogWarning("The driver can't be found");
            }

            orders.text = "Order Destroyed in Transit. Transaction Cancelled.";
            float score = 0;
            timer.text = score.ToString("F2") + "%";
            PrefabOrder.orderHasBeenTaken = false;
            Debug.Log("PrefabOrderPlayer1.orderHasBeenTaken1: " + PrefabOrder.orderHasBeenTaken);
            GameManager.Player1OrderSelected = false;
            player1OrderPickedUp = false;
            player1OrderDelivered = false;
            food.SetActive(false);
            this.transform.position = new Vector3(-10000, -10000, -10000);
            player1TimeScore = 0;
            pointer.SetActive(false);
            timer.text = "";
            StartCoroutine(Waiting());

        }
    }

    void DisplayScore()
    {
        timer.text = finalScore.ToString("F2") + "%";
        StartCoroutine(Waiting2());
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(1.5f);
        PrefabOrder.orderHasBeenTaken = false;
        player1OrderPickedUp = false;
        player1OrderDelivered = false;
        timer.text = finalScore.ToString("F0") + "%";
        orders.text = "Press C to check your phone for orders.";
        pointer.SetActive(false);
    }

    IEnumerator Waiting2()
    {
        yield return new WaitForSeconds(1.5f);
        timer.text = finalScore.ToString("F0") + "%";
    }

    //comment for extra commit
}
