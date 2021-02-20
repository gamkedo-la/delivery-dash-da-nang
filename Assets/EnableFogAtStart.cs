using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableFogAtStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.fog = true;
        //Debug.Log("Script turning on fog so it's not obstructing editor view");
    }
}
