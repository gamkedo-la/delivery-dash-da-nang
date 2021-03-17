using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetermineWhichCar : MonoBehaviour
{
    int RandNumber;
    public GameObject[] carToChoose;
    public GameObject chosenCar;

    private void Start()
    {
        
        RandNumber = Random.Range(0, carToChoose.Length);

        chosenCar = carToChoose[RandNumber];
        chosenCar.SetActive(true);
        //Debug.Log("chosenCar " + chosenCar);
    }
}
