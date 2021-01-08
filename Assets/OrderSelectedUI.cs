using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderSelectedUI : MonoBehaviour
{
    public GameObject text;
    void Update()
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
}
