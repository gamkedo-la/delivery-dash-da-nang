using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RatScript : MonoBehaviour
{
    public Sprite ratIconSprite;

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    private GameObject gameManager;

    
    private void OnTriggerEnter(Collider other)
    {
        gameManager = GameObject.Find("GameManager");
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
        player3 = GameObject.Find("Player3");
        player4 = GameObject.Find("Player4");

        if (other.name == "Player1")
        {
            other.transform.parent.gameObject.transform.Find("Canvas - PlayerPhone").transform.Find("WeaponIcon").GetComponent<Image>().sprite = ratIconSprite;
            other.transform.GetComponent<ScooterDrive>().hasARat = true;
            gameManager.GetComponent<GameManager>().player1HasARat = true;

            gameObject.SetActive(false);            
        }    
        
        else if (other.name == "Player2")
        {
            //Debug.Log(GameObject.Find("Canvas - PlayerPhone2").transform.Find);
            GameObject.Find("Canvas - PlayerPhone2").transform.Find("RatObstructionImage").GetComponent<Image>().sprite = ratIconSprite;
            //player2.transform.GetComponent<ScooterDrive>().hasARat = true;
            gameManager.GetComponent<GameManager>().player2HasARat = true;
            gameObject.SetActive(false);
        }
        else if (other.name == "Player3")
        {
            GameObject.Find("Canvas - PlayerPhone3").transform.Find("RatObstructionImage").GetComponent<Image>().sprite = ratIconSprite;
            //player3.transform.GetComponent<ScooterDrive>().hasARat = true;
            gameManager.GetComponent<GameManager>().player3HasARat = true;

            gameObject.SetActive(false);
        }
        else if (other.name == "Player4")
        {
            GameObject.Find("Canvas - PlayerPhone4").transform.Find("RatObstructionImage").GetComponent<Image>().sprite = ratIconSprite;
            //player4.transform.GetComponent<ScooterDrive>().hasARat = true;
            gameManager.GetComponent<GameManager>().player4HasARat = true;

            gameObject.SetActive(false);
        }
    }
}
