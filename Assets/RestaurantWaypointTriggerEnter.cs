using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestaurantWaypointTriggerEnter : MonoBehaviour
{
    public AudioSource orderPickedUpSFX;

    public static bool player1OrderPickedUp;
    public static bool player1OrderDelivered;

    public GameObject pointer;
    public Text orders;
    public GameObject food;

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
            food.SetActive(false);
            print("Order Completed");
            pointer.SetActive(false);
            //Just getting the box out of the way
            this.transform.position = new Vector3(-10000, -10000, -10000);
            orders.text = "";
            orders.text = "Press C to check your phone for orders.";
            StartCoroutine(Waiting());
        }
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(1.5f);
        player1OrderPickedUp = false;
        player1OrderDelivered = false;
        PrefabOrder.orderHasBeenTaken = false;
    }
}
