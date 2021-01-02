using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestaurantWaypointTriggerEnter : MonoBehaviour
{
    public AudioSource orderPickedUpSFX;
    public GameObject customerWaypointBox;


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("entered");
        if (other.tag == "Player" /*&& GameManager.Player1OrderSelected*/)
        {
            orderPickedUpSFX.Play();
            gameObject.SetActive(false);
            customerWaypointBox.SetActive(true);
            Debug.Log("restaurant box entered");
        }
    }
}
