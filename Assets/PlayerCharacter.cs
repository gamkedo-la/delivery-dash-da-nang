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

    public void Left()
    {
        characters[characterCount].SetActive(false);
        characterCount--;
        if (characterCount < 0 )
        {
            characterCount = characters.Length -1;
        }
        characters[characterCount].SetActive(true);
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
    }

    private void Update()
    {
        characterNameString.text = characterName[characterCount];
    }
}
