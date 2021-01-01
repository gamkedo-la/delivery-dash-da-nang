using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToObjective : MonoBehaviour
{
    public GameObject physicalArrow;
    public Transform restaurantWayPoint, customerWayPoint;

    private void LateUpdate()
    {


        if (GameManager.player1OrderPickedUp)
        {
            this.transform.LookAt(customerWayPoint.position);
        }
        else
        {
            this.transform.LookAt(restaurantWayPoint.position);
        }
    }
}
