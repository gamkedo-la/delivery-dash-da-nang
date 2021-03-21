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
    public static int player1Character, player2Character, player3Character, player4Character;

    public GameObject level;
    LevelLoader levelLoader;

    public bool characterSelectionScreenIsActuallyFocusedOn = false;

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

        if (Input.anyKeyDown)
        {
            GameCreate();
        }
    }

    public void GameCreate()
    {
        main.SetActive(false);
        gamecreation.SetActive(true);
        characterSelectionScreenIsActuallyFocusedOn = true;
    }

    public void gameCreateBack()
    {
        main.SetActive(true);
        gamecreation.SetActive(false);
        characterSelectionScreenIsActuallyFocusedOn = false;
    }

    public void startGame()
    {
        if (!characterSelectionScreenIsActuallyFocusedOn)
        {
            Debug.Log("game recognizes that the character select screen is not focused on");
        }
        if (characterSelectionScreenIsActuallyFocusedOn)
        {
            Debug.Log("character select is focused on");
            //save player character 
            //save player count (this is stored in playerCount)
            //print("PlayerCount:" + playerCount);
            //print("Player1Char:" + player1Character);
            //print("Player2Char:" + player2Character);
            //print("Player3Char:" + player3Character);
            //print("Player4Char:" + player4Character);
            //level.SetActive(true);
            //levelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
            //levelLoader.LoadNextLevel();
        }
        
    }

    public void increasePlayerCount()
    {
        Debug.Log("increasePlayerCount triggered");
        playerCount++;
        if (playerCount > 4)
        {
            playerCount = 1;
        }
        playerCountstring.text = "Player Count: " + playerCount.ToString();
    }

    public void decreasePlayerCount()
    {
        Debug.Log("decreasePlayerCount triggered");

        playerCount--;
        if (playerCount < 1)
        {
            playerCount = 4;
        }

        playerCountstring.text = "Player Count: " + playerCount.ToString();
    }
}
