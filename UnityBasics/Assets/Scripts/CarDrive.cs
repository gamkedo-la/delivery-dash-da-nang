using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDrive : MonoBehaviour
{
    float currentSpeed;
    float forwardSpeed;
    float backwardSpeed;
    float coastToStopSpeed;
    float maxSpeed;

    float turnAngle;
    float turnAngleRate;

    float brakeSpeed;

    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = 0.0f;
        forwardSpeed = Time.deltaTime * 1.0f;
        brakeSpeed = Time.deltaTime * 0.5f;
        coastToStopSpeed = Time.deltaTime * 0.35f;
        maxSpeed = 1.0f;

        backwardSpeed = Time.deltaTime * 0.1f;

        turnAngle = 0.0f;
        turnAngleRate = 8.0f * Time.deltaTime;

        
    }

    void MoveBikeForwardOrBackward()
    {
        transform.position += transform.forward * currentSpeed;
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
            currentSpeed += forwardSpeed * Input.GetAxisRaw("Vertical");
            if (currentSpeed > maxSpeed)
            {
                currentSpeed = maxSpeed;
            }
        }
        else if (!Input.GetKey(KeyCode.F) && currentSpeed > 0)
        {
            currentSpeed += brakeSpeed * Input.GetAxisRaw("Vertical");
            if (currentSpeed < 0)
            {
                currentSpeed = 0;
            }
        }
        if (Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.F))
        {
            currentSpeed -= backwardSpeed;
        }

        //turns
        if (Input.GetKey(KeyCode.RightArrow))
        {
            turnAngle += turnAngleRate * Input.GetAxisRaw("Horizontal");
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            turnAngle += turnAngleRate * Input.GetAxisRaw("Horizontal");
        }
        if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {
            turnAngle = 0;
        }

        //brake
        if (Input.GetKey(KeyCode.Space))
        {
            currentSpeed += brakeSpeed * Input.GetAxisRaw("Vertical");
            if (currentSpeed < 0)
            {
                currentSpeed = 0;
            }
        }

        //coasting to stop
        if (Input.GetKey(KeyCode.Space) == false && Input.GetKey(KeyCode.F) == false)
        {
            currentSpeed -= coastToStopSpeed;
            if (currentSpeed < 0)
            {
                currentSpeed = 0;
            }
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
