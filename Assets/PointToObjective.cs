using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToObjective : MonoBehaviour
{
    public GameObject physicalArrow;
    public Transform restaurantWayPoint, customerWayPoint;
    public GameObject customerOrder;
    public GameObject restaurantWaypointBox, customerWaypointBox;

    private void LateUpdate()
    {

        if (customerOrder.GetComponent<PrefabOrder>().orderHasBeenTaken == true)
        {
            gameObject.SetActive(true);
            restaurantWaypointBox.SetActive(true);
            GameManager.player1OrderPickedUp = true;

            Debug.Log("inisde order selected bool check");
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
}
