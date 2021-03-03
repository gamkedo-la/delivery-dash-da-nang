using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointCheat : MonoBehaviour
{
    public static WaypointCheat instance;

    private void Awake()
    {
        instance = this; 
    }
}
