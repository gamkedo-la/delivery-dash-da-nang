using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToObjective : MonoBehaviour
{
    public GameObject player1WayPointBox;
    public GameObject player2WayPointBox;

    public bool isPlayer1;
    public bool isPlayer2;

    private void Start()
    {
        if (isPlayer1)
        {
            player1WayPointBox = GameObject.Find("WayPointBox - Restaurant");
        }
        if (isPlayer2)
        {
            player2WayPointBox = GameObject.Find("WayPointBox - Restaurant2");
        }
    }

    private void LateUpdate()
    {
        if (isPlayer1)
        {
            this.transform.LookAt(player1WayPointBox.transform.position);
        }
        if (isPlayer2)
        {
            this.transform.LookAt(player2WayPointBox.transform.position);
        }
    }
}
