using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeliveryDriver : MonoBehaviour, IComparable<DeliveryDriver>
{
    public string characterName = "";
    public int score = 0;
    public int scoreOnOrder = 0;
    public int totalOrders = 0;
    public int phoneScore = 0;

    private void Start()
    {
        if (characterName.Length < 1)
        {
            characterName = gameObject.name;
        }
    }

    public void IncreaseOrderTotal(int orderScore)
    {
        score += orderScore;
        totalOrders++;
        phoneScore = (int) score / totalOrders;
        //Debug.Log(characterName + " completed an order, now has a score of: " + score + "/" + totalOrders);
    }

    public void PlayerIncreaseOrderTotal(int orderScore)
    {
        scoreOnOrder += orderScore;
        score += scoreOnOrder;
      //  scoreOnOrder = 0;
        totalOrders++;
        phoneScore = (int)score / totalOrders;
        //Debug.Log(characterName + " completed an order, now has a score of: " + score + "/" + totalOrders);
    }

    public int CompareTo(DeliveryDriver toCompare)
    {
        int ComparisonResult = score.CompareTo(toCompare.score);
        if (ComparisonResult == 0)
        {
            return characterName.CompareTo(toCompare.characterName);
        }
        return ComparisonResult;
    }
}
