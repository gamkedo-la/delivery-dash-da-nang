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
        //chosenCar.SetActive(true);
        GameObject newCar = GameObject.Instantiate(chosenCar);
        newCar.SetActive(true);
        newCar.transform.parent = transform;
        newCar.transform.position = transform.position;
        newCar.transform.rotation = transform.rotation;
        //Debug.Log("chosenCar " + chosenCar);
    }
}
