using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class RatingsManager : MonoBehaviour
{
    [SerializeField] private RectTransform ratingsContainer;
    [SerializeField] private GameObject ratingUI;
    [SerializeField] private List<CustomerRating> ratings;

    [SerializeField] private string[] oneStarReviews;
    [SerializeField] private string[] twoStarReviews;
    [SerializeField] private string[] threeStarReviews;
    [SerializeField] private string[] fourStarReviews;
    [SerializeField] private string[] fiveStarReviews;

    public void AddRating(CustomerRating rating)
    {
        // If no ratings are present, remove children from ratingsContainer to remove the
        // "no ratings yet" message.
        if (ratings.Count == 0)
        {
            ClearRatings();
        }
        ratings.Add(rating);

        // Create rating UI instance.
        var ratingInstance = Instantiate(ratingUI, ratingsContainer);
        ratingInstance.GetComponent<CustomerRatingDisplayMapper>()?.SetCustomerRating(rating);
    }

    public CustomerRating CreateRating(int stars)
    {
        var rating = ScriptableObject.CreateInstance<CustomerRating>();
        rating.rating = stars;
        rating.customerName = "Franklin D.";

        var rand = new Random();
        var i = 0;
        switch (stars)
        {
            case 1:
                i = rand.Next(0, oneStarReviews.Length - 1);
                rating.customerMessage = oneStarReviews[i];
                break;
            case 2:
                i = rand.Next(0, twoStarReviews.Length - 1);
                rating.customerMessage = twoStarReviews[i];
                break;
            case 3:
                i = rand.Next(0, threeStarReviews.Length - 1);
                rating.customerMessage = threeStarReviews[i];
                break;
            case 4:
                i = rand.Next(0, fourStarReviews.Length - 1);
                rating.customerMessage = fourStarReviews[i];
                break;
            case 5:
                i = rand.Next(0, fiveStarReviews.Length - 1);
                rating.customerMessage = fiveStarReviews[i];
                break;
        }
        return rating;
    }

    private void ClearRatings()
    {
        var childCount = ratingsContainer.childCount;

        for (var i = childCount - 1; i >= 0; i--)
        {
            var child = ratingsContainer.GetChild(i).gameObject;
            child.transform.SetParent(null, false);
            Destroy(child);
        }
    }
}
