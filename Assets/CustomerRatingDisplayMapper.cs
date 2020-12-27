using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerRatingDisplayMapper : MonoBehaviour
{
    [SerializeField] private Text customerName;
    [SerializeField] private Text customerMessage;
    [SerializeField] private RectTransform starsContainer;
    [SerializeField] private GameObject emptyStar;
    [SerializeField] private GameObject fullStar;

    private CustomerRating customerRating;

    public void SetCustomerRating(CustomerRating rating)
    {
        customerRating = rating;
        customerName.text = customerRating.customerName;
        customerMessage.text = customerRating.customerMessage;

        var numFullStars = Math.Min(rating.rating, 5);
        for (var i = 0; i < numFullStars; i++)
        {
            Instantiate(fullStar, starsContainer);
        }

        var numEmptyStars = Math.Max(5 - numFullStars, 0);
        for (var i = 0; i < numEmptyStars; i++)
        {
            Instantiate(emptyStar, starsContainer);
        }
    }
}
