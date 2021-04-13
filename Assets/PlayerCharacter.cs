using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacter : MonoBehaviour
{
    public GameObject[] characters;
    public string[] characterName;
    public int characterCount = 0;
    public Text characterNameString;

    public bool player1, player2, player3, player4;

    public GameObject mainCamera;
    MainMenu mainMenuScript;

    public Text playerstats;


    private void Awake()
    {
        mainMenuScript = mainCamera.GetComponent<MainMenu>();
    }

    public void Left()
    {
        characters[characterCount].SetActive(false);
        characterCount--;
        if (characterCount < 0 )
        {
            characterCount = characters.Length -1;
        }
        characters[characterCount].SetActive(true);
        if (player1)
        {
            MainMenu.player1Character = characterCount;
        }
        if (player2)
        {
            MainMenu.player2Character = characterCount;
        }
        if (player3)
        {
            MainMenu.player3Character = characterCount;
        }
        if (player4)
        {
            MainMenu.player4Character = characterCount;
        }

        if (characterCount == 0)
        {
            playerstats.text = "70   33    12   30";
        }
        if (characterCount == 1)
        {
            playerstats.text = "50   45    30    50";
        }
        if (characterCount == 2)
        {
            playerstats.text = "90   20     5    20";
        }
        if (characterCount == 3)
        {
            playerstats.text = "60   50    15    30";
        }
    }

    public void Right()
    {
        characters[characterCount].SetActive(false);
        characterCount++;
        if (characterCount == characters.Length)
        {
            characterCount = 0;
        }
        characters[characterCount].SetActive(true);
        if (player1)
        {
            MainMenu.player1Character = characterCount;
        }
        if (player2)
        {
            MainMenu.player2Character = characterCount;
        }
        if (player3)
        {
            MainMenu.player3Character = characterCount;
        }
        if (player4)
        {
            MainMenu.player4Character = characterCount;
        }

        if (characterCount == 0)
        {
            playerstats.text = "70   33   12   30";
        }
        if (characterCount == 1)
        {
            playerstats.text = "50   45    30    50";
        }
        if (characterCount == 2)
        {
            playerstats.text = "90   20     5    20";
        }
        if (characterCount == 3)
        {
            playerstats.text = "60   50    15    30";
        }
    }

    private void Update()
    {
        characterNameString.text = characterName[characterCount];
    }

    public void HandleLeftShoulderButton()
    {
        mainMenuScript.decreasePlayerCount();
    }

    public void HandleRightShoulderButton()
    {
        mainMenuScript.increasePlayerCount();
    }

    public void HandleLeftAnalogPressedRight()
    {
        Right();
    }

    public void HandleLeftAnalogPressedLeft()
    {
        Left();
    }

    
}
