using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderSystem : MonoBehaviour
{
    /* 1. Assign random orders to start
     * 2. Buttons so player can accept order
     * 3. remove order from the list
     * 4. add order to the player UI
     * 5. list can be added to at random and orders can be removed at random (if not selected)
     * 6. Ability to cancel order once accepted
     * */

    public string[] restaurantName;
    public string[] productName;

    public Transform[] customerLocations;
    public string[] apartmentName;
    public string[] customerNames;

    public int restaurantSelected;
    public int customerLocation;
    public int customerName;


}
