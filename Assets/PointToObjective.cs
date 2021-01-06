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
            
            //gameObject.SetActive(true);
            //restaurantWaypointBox.SetActive(true);
            //GameManager.player1OrderPickedUp = true;

            //print("customer order restaurant name: " + customerOrder.GetComponent<PrefabOrder>().restaurantName);
            if (GameManager.player1OrderPickedUp)
            {
                //Debug.Log("inside order picked up");
                this.transform.LookAt(customerWayPoint.position);
            }
            else
            {
                //Debug.Log("inside order not picked up");
                this.transform.LookAt(restaurantWayPoint.position);
            }
        } 
    }
}
