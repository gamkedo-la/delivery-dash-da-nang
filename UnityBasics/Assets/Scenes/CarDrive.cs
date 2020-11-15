using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDrive : MonoBehaviour
{
    float totalSpeed;
    float forwardSpeed;
    float backwardSpeed;

    float turnAngle;
    float turnAngleRate;

    float brakeSpeed;

    // Start is called before the first frame update
    void Start()
    {
        totalSpeed = 0.0f;
        forwardSpeed = Time.deltaTime * 0.6f;
        backwardSpeed = Time.deltaTime * 0.5f;

        turnAngle = 0.0f;
        turnAngleRate = 80.0f * Time.deltaTime;

        brakeSpeed = Time.deltaTime * 0.4f;
    }

    void MoveBikeForwardOrBackward()
    {
        transform.position += transform.forward * totalSpeed;
    }

    void TurnBikeLeftOrRight()
    {
        transform.Rotate(Vector3.up, turnAngle);
    }

    void HandleControlKeys()
    {
        //forward and backwards
        if (Input.GetKey(KeyCode.F))
        {
            totalSpeed += forwardSpeed;
        }
        else if (!Input.GetKey(KeyCode.F) && totalSpeed > 0)
        {
            totalSpeed -= brakeSpeed;
            if (totalSpeed < 0)
            {
                totalSpeed = 0;
            }
        }
        if (Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.F))
        {
            totalSpeed -= backwardSpeed;
        }

        //turns
        if (Input.GetKey(KeyCode.RightArrow))
        {
            turnAngle += turnAngleRate;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            turnAngle -= turnAngleRate;
        }
        if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {
            turnAngle = 0;
        }

        //brake
        if (Input.GetKey(KeyCode.Space))
        {
            totalSpeed -= brakeSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandleControlKeys();
        MoveBikeForwardOrBackward();
        TurnBikeLeftOrRight();
    }// end of update(){}
}// end of class
