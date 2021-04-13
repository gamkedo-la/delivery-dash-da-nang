using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestaurantWaypoint4 : MonoBehaviour
{
    public AudioSource orderPickedUpSFX, chachingSFX;

    public static bool player4OrderPickedUp;
    public static bool player4OrderDelivered;

    public static float player4TimeScore, player4TimeScoreMax;

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

        if (other.tag == "Player" && other.name == "Player4")
        {
            receivedDriver = other.GetComponent<DeliveryDriver>();

            if (PrefabOrderPlayer4.orderHasBeenTaken4)
            {
                if (player4OrderPickedUp && !player4OrderDelivered && player.GetComponent<ScooterDrive>().currentSpeed == 0)
                {
                    player4OrderDelivered = true;
                    chachingSFX.Play();
                    GameManager.Player4OrderSelected = false;
                    gpsScript.ClearPath();
                }

                if (!player4OrderPickedUp && player.GetComponent<ScooterDrive>().currentSpeed == 0)
                {
                    player4OrderPickedUp = true;
                    orderPickedUpSFX.Play();
                    food.SetActive(true);
                    this.gameObject.transform.position = GameObject.Find("Player4Apartment").transform.position;
                    orders.text = "Deliver " + GameManager.Player4CustomerItemOrdered + " to " + GameManager.Player4CustomerName + " at " + $"<color=yellow>{GameManager.Player4ApartmentName}</color>";
                    customerNode = gpsScript.FindNearestNode(gameObject.transform);
                    nodeNearestToPlayer = gpsScript.FindNearestNode(player.transform);
                    gpsScript.FindPath(nodeNearestToPlayer, customerNode);
                }
            }
        }

    }

    private void Update()
    {
        if (PrefabOrderPlayer4.orderHasBeenTaken4 && player4OrderPickedUp && player4OrderDelivered)
        {
            player.GetComponent<ScooterDrive>().AssignStars();
            float score = (player4TimeScore / player4TimeScoreMax) * 100;
            float score2 = FoodHealth.currentHealth4;
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
            PrefabOrderPlayer4.orderHasBeenTaken4 = false;
            player4OrderPickedUp = false;
            player4OrderDelivered = false;
            food.SetActive(false);
            pointer.SetActive(false);
            //Just getting the box out of the way
            this.transform.position = new Vector3(-10000, -10000, -10000);
            orders.text = "Order Completed";
            timer.text = "";
            StartCoroutine(Waiting());
        }

        if (PrefabOrderPlayer4.orderHasBeenTaken4)
        {
            player4TimeScore -= Time.deltaTime;
            //if (player4TimeScore < 10f)
            //{
            //    player4TimeScore = 10f;
            //}    
            timer.text = player4TimeScore.ToString("F2");
        }

        if (player4TimeScore < 0)
        {
            player.GetComponent<ScooterDrive>().AssignStars();
            //Order failed on Time
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
            PrefabOrderPlayer4.orderHasBeenTaken4 = false;
            Debug.Log("PrefabOrderPlayer4.orderHasBeenTaken4: " + PrefabOrderPlayer4.orderHasBeenTaken4);
            GameManager.Player4OrderSelected = false;
            player4OrderPickedUp = false;
            player4OrderDelivered = false;
            food.SetActive(false);
            this.transform.position = new Vector3(-10000, -10000, -10000);
            player4TimeScore = 0;
            pointer.SetActive(false);
            timer.text = "";
            StartCoroutine(Waiting());

        }

        if (FoodHealth.currentHealth4 < 0)
        {
            player.GetComponent<ScooterDrive>().AssignStars();
            //Order failed on Time
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
            PrefabOrderPlayer4.orderHasBeenTaken4 = false;
            Debug.Log("PrefabOrderPlayer4.orderHasBeenTaken4: " + PrefabOrderPlayer4.orderHasBeenTaken4);
            GameManager.Player4OrderSelected = false;
            player4OrderPickedUp = false;
            player4OrderDelivered = false;
            food.SetActive(false);
            this.transform.position = new Vector3(-10000, -10000, -10000);
            player4TimeScore = 0;
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
        PrefabOrderPlayer4.orderHasBeenTaken4 = false;
        FoodHealth.currentHealth4 = 1000;
        player4OrderPickedUp = false;
        player4OrderDelivered = false;
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

