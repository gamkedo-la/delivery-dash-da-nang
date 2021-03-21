using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestaurantWaypoint2 : MonoBehaviour
{
    public AudioSource orderPickedUpSFX, chachingSFX;

    public static bool player2OrderPickedUp;
    public static bool player2OrderDelivered;

    public static float player2TimeScore, player2TimeScoreMax;

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

        if (other.tag == "Player")
        {
            receivedDriver = other.GetComponent<DeliveryDriver>();

            if (PrefabOrderPlayer2.orderHasBeenTaken2)
            {
                if (player2OrderPickedUp && !player2OrderDelivered && player.GetComponent<ScooterDrive>().currentSpeed == 0)
                {
                    player2OrderDelivered = true;
                    chachingSFX.Play();
                    GameManager.Player2OrderSelected = false;
                    gpsScript.ClearPath();
                }

                if (!player2OrderPickedUp && player.GetComponent<ScooterDrive>().currentSpeed == 0)
                {
                    player2OrderPickedUp = true;
                    orderPickedUpSFX.Play();
                    this.gameObject.transform.position = GameObject.Find("Player2Apartment").transform.position;
                    orders.text = "Deliver " + GameManager.Player2CustomerItemOrdered + " to " + GameManager.Player2CustomerName + " at " + $"<color=yellow>{GameManager.Player2ApartmentName}</color>";
                    customerNode = gpsScript.FindNearestNode(gameObject.transform);
                    nodeNearestToPlayer = gpsScript.FindNearestNode(player.transform);
                    gpsScript.FindPath(nodeNearestToPlayer, customerNode);
                }
            }
        }

    }

    private void Update()
    {
        if (PrefabOrderPlayer2.orderHasBeenTaken2 && player2OrderPickedUp && player2OrderDelivered)
        {
            player.GetComponent<ScooterDrive>().AssignStars();
            float score = (player2TimeScore / player2TimeScoreMax) * 100;
            float score2 = FoodHealth.currentHealth2;
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
            PrefabOrderPlayer2.orderHasBeenTaken2 = false;
            player2OrderPickedUp = false;
            player2OrderDelivered = false;
            food.SetActive(false);
            pointer.SetActive(false);
            //Just getting the box out of the way
            this.transform.position = new Vector3(-10000, -10000, -10000);
            orders.text = "Order Completed";
            timer.text = "";
            StartCoroutine(Waiting());
        }

        if (PrefabOrderPlayer2.orderHasBeenTaken2)
        {
            player2TimeScore -= Time.deltaTime;
            timer.text = player2TimeScore.ToString("F2");
        }

        if (player2TimeScore < 0)
        {
            //Order failed on Time
            orders.text = "Order Not Delivered in Time. Transaction Cancelled.";
            float score = 0;
            timer.text = score.ToString("F2") + "%";
            PrefabOrderPlayer2.orderHasBeenTaken2 = false;
            food.SetActive(false);
            this.transform.position = new Vector3(-10000, -10000, -10000);
            player2TimeScore = 0;
            pointer.SetActive(false);
            timer.text = "";
            StartCoroutine(Waiting());

        }

        if (FoodHealth.currentHealth2 < 0)
        {
            //Order failed on Time
            orders.text = "Order Destroyed in Transit. Transaction Cancelled.";
            float score = 0;
            timer.text = score.ToString("F2") + "%";
            PrefabOrderPlayer2.orderHasBeenTaken2 = false;
            food.SetActive(false);
            this.transform.position = new Vector3(-10000, -10000, -10000);
            player2TimeScore = 0;
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
        PrefabOrderPlayer2.orderHasBeenTaken2 = false;
        player2OrderPickedUp = false;
        player2OrderDelivered = false;
        timer.text = finalScore.ToString("F0") + "%";
        orders.text = "Press C to check your phone for orders.";
        pointer.SetActive(false);
    }

    IEnumerator Waiting2()
    {
        yield return new WaitForSeconds(1.5f);
        timer.text = finalScore.ToString("F0") + "%";
    }
}
