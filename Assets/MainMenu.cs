using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject main, gamecreation;

    public static int playerCount;
    public Text playerCountstring;

    public GameObject player1, player2, player3, player4;

    private void Start()
    {
        playerCount = 1;
    }

    private void Update()
    {
        if (playerCount == 1)
        {
            player1.SetActive(true);
            player2.SetActive(false);
            player3.SetActive(false);
            player4.SetActive(false);
        }

        if (playerCount == 2)
        {
            player1.SetActive(true);
            player2.SetActive(true);
            player3.SetActive(false);
            player4.SetActive(false);
        }

        if (playerCount == 3)
        {
            player1.SetActive(true);
            player2.SetActive(true);
            player3.SetActive(true);
            player4.SetActive(false);
        }

        if (playerCount == 4)
        {
            player1.SetActive(true);
            player2.SetActive(true);
            player3.SetActive(true);
            player4.SetActive(true);
        }
    }

    public void GameCreate()
    {
        main.SetActive(false);
        gamecreation.SetActive(true);
    }

    public void gameCreateBack()
    {
        main.SetActive(true);
        gamecreation.SetActive(false);
    }

    public void startGame()
    {
        //save player character 
        //save player count (this is stored in playerCount)
        print(playerCount);
        SceneManager.LoadScene("DaytimeDaNang");
    }

    public void increasePlayerCount()
    {
        playerCount++;
        if (playerCount > 4)
        {
            playerCount = 1;
        }
        playerCountstring.text = "Player Count: " + playerCount.ToString();
    }

    public void decreasePlayerCount()
    {
        playerCount--;
        if (playerCount < 1)
        {
            playerCount = 4;
        }

        playerCountstring.text = "Player Count: " + playerCount.ToString();
    }
}
