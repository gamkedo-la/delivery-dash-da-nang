using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToObjective : MonoBehaviour
{
    public GameObject player1WayPointBox;
    public GameObject player2WayPointBox;
    public GameObject player3WayPointBox;
    public GameObject player4WayPointBox;

    public bool isPlayer1;
    public bool isPlayer2;
    public bool isPlayer3;
    public bool isPlayer4;

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
            if (isPlayer3)
            {
                player3WayPointBox = GameObject.Find("WayPointBox - Restaurant3");
            }
            if (isPlayer4)
            {
                player4WayPointBox = GameObject.Find("WayPointBox - Restaurant4");
            }

        if (!MainMenu.normal)
        {
            player1WayPointBox.SetActive(false);
            player2WayPointBox.SetActive(false);
            player3WayPointBox.SetActive(false);
            player4WayPointBox.SetActive(false);
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
        if (isPlayer3)
        {
            this.transform.LookAt(player3WayPointBox.transform.position);
        }
        if (isPlayer4)
        {
            this.transform.LookAt(player4WayPointBox.transform.position);
        }
    }
}
