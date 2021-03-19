using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneMenus : MonoBehaviour
{
    public bool orders, gps, ratings, scores;
    public GameObject phoneScript;

    void Update()
    {

    }

    public void ButtonPressed()
    {
        if (orders)
        {
            phoneScript.GetComponentInParent<PhoneScript>().OrdersBack();
        }

        if (gps)
        {
            phoneScript.GetComponentInParent<PhoneScript>().GPSButtonBack();
        }

        if (ratings)
        {
            phoneScript.GetComponentInParent<PhoneScript>().RatingsBack();
        }

        if (scores)
        {
            phoneScript.GetComponentInParent<PhoneScript>().CustomerScoresBack();
        }
    }
}
