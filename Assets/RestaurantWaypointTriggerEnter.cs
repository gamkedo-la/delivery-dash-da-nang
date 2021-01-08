using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestaurantWaypointTriggerEnter : MonoBehaviour
{
    public AudioSource orderPickedUpSFX;

    public static bool player1OrderPickedUp;
    public static bool player1OrderDelivered;

    public static float player1TimeScore, player1TimeScoreMax;

    public GameObject pointer;
    public Text orders, timer;
    public GameObject food;

    float finalScore;

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            orderPickedUpSFX.Play();
            if (PrefabOrder.orderHasBeenTaken)
            {
                if (player1OrderPickedUp && !player1OrderDelivered)
                {
                    player1OrderDelivered = true;
                }

                if (!player1OrderPickedUp)
                {
                    player1OrderPickedUp = true;
                    this.gameObject.transform.position = GameObject.Find("Player1Apartment").transform.position;
                }
            }
        }

    }

    private void Update()
    {
        if (PrefabOrder.orderHasBeenTaken && player1OrderPickedUp && player1OrderDelivered)
        {
            float score = (player1TimeScore / player1TimeScoreMax) * 100;
            float score2 = FoodHealth.currentHealth;
            finalScore = (score + score2) / 2;
            timer.text = finalScore.ToString("F2") + "%";
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
            timer.text = player1TimeScore.ToString("F2");
        }

        if (player1TimeScore < 0)
        {
            //Order failed on Time
            orders.text = "Order Not Delivered in Time. Transaction Cancelled.";
            float score = 0;
            timer.text = score.ToString("F2") + "%";
            PrefabOrder.orderHasBeenTaken = false;
            food.SetActive(false);
            this.transform.position = new Vector3(-10000, -10000, -10000);
            player1TimeScore = 0;
            pointer.SetActive(false);
            timer.text = "";
            StartCoroutine(Waiting());

        }

        if (FoodHealth.currentHealth < 0)
        {
            //Order failed on Time
            orders.text = "Order Destroyed in Transit. Transaction Cancelled.";
            float score = 0;
            timer.text = score.ToString("F2") + "%";
            PrefabOrder.orderHasBeenTaken = false;
            food.SetActive(false);
            this.transform.position = new Vector3(-10000, -10000, -10000);
            player1TimeScore = 0;
            pointer.SetActive(false);
            timer.text = "";
            StartCoroutine(Waiting());

        }
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(1.5f);
        PrefabOrder.orderHasBeenTaken = false;
        player1OrderPickedUp = false;
        player1OrderDelivered = false;
        timer.text = finalScore.ToString("F0") + "%";
        orders.text = "Press C to check your phone for orders.";
    }
}
