using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToObjective : MonoBehaviour
{
    public GameObject physicalArrow;
    public GameObject player1WayPointBox;

    public bool isPlayer1;

    private void Start()
    {
        if (isPlayer1)
        {
            player1WayPointBox = GameObject.Find("WayPointBox - Restaurant");
        }
    }

    private void LateUpdate()
    {
        if (isPlayer1)
        {
            this.transform.LookAt(player1WayPointBox.transform.position);
        }
    }
}
