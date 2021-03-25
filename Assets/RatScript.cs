using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RatScript : MonoBehaviour
{
    public Sprite ratIconSprite;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player1" || other.name == "Player2" || other.name == "Player3" || other.name == "Player4")
        {
            
            other.transform.parent.gameObject.transform.Find("Canvas - PlayerPhone").transform.Find("WeaponIcon").GetComponent<Image>().sprite = ratIconSprite;
            other.transform.GetComponent<ScooterDrive>().hasARat = true;
            Debug.Log("other.transform.GetComponent<ScooterDrive>().hasARat: " + other.transform.GetComponent<ScooterDrive>().hasARat);

            gameObject.SetActive(false);            
        }     
    }
}
