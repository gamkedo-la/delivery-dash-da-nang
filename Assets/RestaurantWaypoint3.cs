using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestaurantWaypoint3 : MonoBehaviour
{
    public AudioSource orderPickedUpSFX, chachingSFX;

    public static bool player3OrderPickedUp;
    public static bool player3OrderDelivered;

    public static float player3TimeScore, player3TimeScoreMax;

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

        if (other.tag == "Player" && other.name == "Player3")
        {
            receivedDriver = other.GetComponent<DeliveryDriver>();
            if (PrefabOrderPlayer3.orderHasBeenTaken3)
            {
                
                if (player3OrderPickedUp && !player3OrderDelivered && player.GetComponent<ScooterDrive>().currentSpeed == 0)
                {
                    player3OrderDelivered = true;
                    chachingSFX.Play();
                    GameManager.Player3OrderSelected = false;
                    gpsScript.ClearPath();
                }

                if (!player3OrderPickedUp && player.GetComponent<ScooterDrive>().currentSpeed == 0)
                {
                    player3OrderPickedUp = true;
                    orderPickedUpSFX.Play();
                    food.SetActive(true);
                    this.gameObject.transform.position = GameObject.Find("Player3Apartment").transform.position;
                    orders.text = "Deliver " + GameManager.Player3CustomerItemOrdered + " to " + GameManager.Player3CustomerName + " at " + $"<color=yellow>{GameManager.Player3ApartmentName}</color>";
                    customerNode = gpsScript.FindNearestNode(gameObject.transform);
                    nodeNearestToPlayer = gpsScript.FindNearestNode(player.transform);
                    gpsScript.FindPath(nodeNearestToPlayer, customerNode);
                }
            }
        }

    }

    private void Update()
    {
        if (PrefabOrderPlayer3.orderHasBeenTaken3 && player3OrderPickedUp && player3OrderDelivered)
        {
            player.GetComponent<ScooterDrive>().AssignStars();
            float score = (player3TimeScore / player3TimeScoreMax) * 100;
            float score2 = FoodHealth.currentHealth3;
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
            PrefabOrderPlayer3.orderHasBeenTaken3 = false;
            player3OrderPickedUp = false;
            player3OrderDelivered = false;
            food.SetActive(false);
            pointer.SetActive(false);
            //Just getting the box out of the way
            this.transform.position = new Vector3(-10000, -10000, -10000);
            orders.text = "Order Completed";
            timer.text = "";
            StartCoroutine(Waiting());
        }

        if (PrefabOrderPlayer3.orderHasBeenTaken3)
        {
            player3TimeScore -= Time.deltaTime;
            if (player3TimeScore < 10f)
            {
                player3TimeScore = 10f;
            }
            timer.text = player3TimeScore.ToString("F2");
        }

        if (player3TimeScore < 0)
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
            PrefabOrderPlayer3.orderHasBeenTaken3 = false;
            Debug.Log("PrefabOrderPlayer3.orderHasBeenTaken3: " + PrefabOrderPlayer3.orderHasBeenTaken3);
            GameManager.Player3OrderSelected = false;
            player3OrderPickedUp = false;
            player3OrderDelivered = false;
            food.SetActive(false);
            this.transform.position = new Vector3(-10000, -10000, -10000);
            player3TimeScore = 0;
            pointer.SetActive(false);
            timer.text = "";
            StartCoroutine(Waiting());

        }

        if (FoodHealth.currentHealth3 < 0)
        {
            player.GetComponent<ScooterDrive>().AssignStars();
            if (receivedDriver != null)
            {
                receivedDriver.PlayerIncreaseOrderTotal((int)finalScore);
            }
            else
            {
                Debug.LogWarning("The driver can't be found");
            }//Order failed on Time


            orders.text = "Order Destroyed in Transit. Transaction Cancelled.";
            float score = 0;
            timer.text = score.ToString("F2") + "%";
            PrefabOrderPlayer3.orderHasBeenTaken3 = false;
            Debug.Log("PrefabOrderPlayer3.orderHasBeenTaken3: " + PrefabOrderPlayer3.orderHasBeenTaken3);
            GameManager.Player3OrderSelected = false;
            player3OrderPickedUp = false;
            player3OrderDelivered = false;
            food.SetActive(false);
            this.transform.position = new Vector3(-10000, -10000, -10000);
            player3TimeScore = 0;
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
        PrefabOrderPlayer3.orderHasBeenTaken3 = false;
        player3OrderPickedUp = false;
        player3OrderDelivered = false;
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
