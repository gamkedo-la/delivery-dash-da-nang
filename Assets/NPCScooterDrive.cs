using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScooterDrive : MonoBehaviour
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

    //public Transform restartAt;
    //Rigidbody scootersRigidbodyComponent;

    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = 0.25f;
        forwardSpeed = 0.3f;
        brakeSpeed = 0.5f;
        coastToStopSpeed = 0.35f;
        maxSpeed = 1.0f;

        backwardSpeed = 0.1f;

        currentTurnAngle = 0.0f;
        turnAngleRate = 2.0f;
        maxTurnAngle = 8.0f;
    }

    void stopScooterMovement()
    {
        //scootersRigidbodyComponent.angularVelocity = Vector3.zero;
        currentSpeed = 0.0f;
        currentTurnAngle = 0.0f;
    }

    void MoveBikeForwardOrBackward()
    {
        transform.position += transform.forward * currentSpeed;
    }

    public void turnRight()
    {
        gameObject.transform.Rotate(0.0f, 90.0f, 0.0f);
    }

    public void turnAround()
    {
        gameObject.transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        MoveBikeForwardOrBackward();
    }
}
