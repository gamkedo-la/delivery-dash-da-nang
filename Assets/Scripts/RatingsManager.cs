using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatingsManager : MonoBehaviour
{
    [SerializeField] private RectTransform ratingsContainer;
    [SerializeField] private GameObject ratingUI;
    [SerializeField] private List<CustomerRating> ratings;

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
