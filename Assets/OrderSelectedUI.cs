using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderSelectedUI : MonoBehaviour
{
    public bool player1, player2, player3, player4;

    public GameObject text;
    void Update()
    {

        if (player1)
        {
            if (PrefabOrder.orderHasBeenTaken)
            {
                this.GetComponent<Image>().enabled = true;
                text.SetActive(true);
            }

            else
            {
                this.GetComponent<Image>().enabled = false;
                text.SetActive(false);
            }
        }

        if (player2)
        {
            if (PrefabOrderPlayer2.orderHasBeenTaken2)
            {
                this.GetComponent<Image>().enabled = true;
                text.SetActive(true);
            }

            else
            {
                this.GetComponent<Image>().enabled = false;
                text.SetActive(false);
            }
        }

        if (player3)
        {
            if (PrefabOrderPlayer3.orderHasBeenTaken3)
            {
                this.GetComponent<Image>().enabled = true;
                text.SetActive(true);
            }

            else
            {
                this.GetComponent<Image>().enabled = false;
                text.SetActive(false);
            }
        }

        if (player4)
        {
            if (PrefabOrderPlayer4.orderHasBeenTaken4)
            {
                this.GetComponent<Image>().enabled = true;
                text.SetActive(true);
            }

            else
            {
                this.GetComponent<Image>().enabled = false;
                text.SetActive(false);
            }
        }
    }
}
