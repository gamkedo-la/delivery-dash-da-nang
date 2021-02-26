using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetermineWhichCar : MonoBehaviour
{
    int RandNumber;
    public GameObject[] carToChoose;

    private void Start()
    {
        RandNumber = Random.Range(0, carToChoose.Length);
        carToChoose[RandNumber].SetActive(true);
    }
}
