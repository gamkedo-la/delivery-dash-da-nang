﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateGrid : MonoBehaviour
{
    public GameObject prefab;

    public int numberToCreate1, numberToCreate2, numberToCreate3, numberToCreate4;

    public bool player1, player2, player3, player4;

    private void Start()
    {
        InitialPopulate();
    }

    void InitialPopulate()
    {
        GameObject newObj;
        for (int i = 0; i < numberToCreate1; i++)
        {
            newObj = (GameObject)Instantiate(prefab, transform);
           // newObj.GetComponent<Image>().color = Random.ColorHSV();
        }
    }

    public void DeductCount()
    {
        if (player1)
        {
            numberToCreate1--;
            AddPlayer1();
        }
        if (player2)
        {
            numberToCreate2--;
            AddPlayer2();
        }
        if (player3)
        {
            numberToCreate3--;
            AddPlayer3();
        }
        if (player4)
        {
            numberToCreate4--;
            AddPlayer4();
        }
    }

    public void AddPlayer1()
    {
        if (player1 && numberToCreate1 <= 3)
        {
            int randNew = Random.Range(3, 7);
            numberToCreate1 += randNew;
            GameObject newObj;
            for (int i = 0; i < randNew; i++)
            {
                newObj = (GameObject)Instantiate(prefab, transform);
                // newObj.GetComponent<Image>().color = Random.ColorHSV();
            }
        }
    }

    public void AddPlayer2()
    {
        if (player2 && numberToCreate2 <= 3)
        {
            int randNew = Random.Range(3, 7);
            numberToCreate2 += randNew;
            GameObject newObj;
            for (int i = 0; i < randNew; i++)
            {
                newObj = (GameObject)Instantiate(prefab, transform);
                // newObj.GetComponent<Image>().color = Random.ColorHSV();
            }
        }
    }

    public void AddPlayer3()
    {
        if (player3 && numberToCreate3 <= 3)
        {
            int randNew = Random.Range(3, 7);
            numberToCreate3 += randNew;
            GameObject newObj;
            for (int i = 0; i < randNew; i++)
            {
                newObj = (GameObject)Instantiate(prefab, transform);
                // newObj.GetComponent<Image>().color = Random.ColorHSV();
            }
        }
    }

    public void AddPlayer4()
    {
        if (player4 && numberToCreate4 <= 3)
        {
            int randNew = Random.Range(3, 7);
            numberToCreate4 += randNew;
            GameObject newObj;
            for (int i = 0; i < randNew; i++)
            {
                newObj = (GameObject)Instantiate(prefab, transform);
                // newObj.GetComponent<Image>().color = Random.ColorHSV();
            }
        }
    }
}
