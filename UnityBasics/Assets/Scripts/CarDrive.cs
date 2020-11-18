using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDrive : MonoBehaviour
{
    public float currentSpeed;
    public float forwardSpeed;
    public float backwardSpeed;
    public float coastToStopSpeed;
    public float maxSpeed;

    public float currentTurnAngle;
    public float turnAngleRate;
    public float maxTurnAngle;

    public float brakeSpeed;

    public Transform restartAt;

    // Start is called before the first frame update
    void Start()
    {
        RestartAtSpawn();

        currentSpeed = 0.0f;
        forwardSpeed = 1.0f;
        brakeSpeed = 0.5f;
        coastToStopSpeed = 0.35f;
        maxSpeed = 1.0f;

        backwardSpeed = 0.1f;

        currentTurnAngle = 0.0f;
        turnAngleRate = 2.0f;
        maxTurnAngle = 8.0f;
    }

    public void RestartAtSpawn()
    {
        transform.position = restartAt.position;
        transform.rotation = restartAt.rotation;
    }

    void MoveBikeForwardOrBackward()
    {
        transform.position += transform.forward * currentSpeed;
    }

    void TurnBikeLeftOrRight()
    {
        transform.Rotate(Vector3.up, currentTurnAngle);
    }

    void HandleControlKeys()
    {
        //forward and backwards
        if (Input.GetKey(KeyCode.F))
        {
            currentSpeed += forwardSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical");
            if (currentSpeed > maxSpeed)
            {
                currentSpeed = maxSpeed;
            }
        }
        else if (!Input.GetKey(KeyCode.F) && currentSpeed > 0)
        {
            currentSpeed += Time.deltaTime * brakeSpeed * Input.GetAxisRaw("Vertical");
            if (currentSpeed < 0)
            {
                currentSpeed = 0;
            }
        }
        if (Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.F))
        {
            currentSpeed -= Time.deltaTime * backwardSpeed;
        }

        //turns
        if (Input.GetKey(KeyCode.RightArrow))
        {
            currentTurnAngle += Time.deltaTime * turnAngleRate * Input.GetAxisRaw("Horizontal");
            if (currentTurnAngle > maxTurnAngle)
            {
                currentTurnAngle = maxTurnAngle;
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            currentTurnAngle += Time.deltaTime * turnAngleRate * Input.GetAxisRaw("Horizontal");
            if (currentTurnAngle < -maxTurnAngle)
            {
                currentTurnAngle = -maxTurnAngle;
            }
        }
        if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {
            currentTurnAngle = 0;
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
            currentSpeed -= Time.deltaTime * coastToStopSpeed;
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
