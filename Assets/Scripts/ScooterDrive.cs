using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScooterDrive : MonoBehaviour
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

    public GameObject brakeLights;

    public Transform restartAt;
    Rigidbody scootersRigidbodyComponent;

    public GameObject bikeModel;

    // Start is called before the first frame update
    void Start()
    {
        //RestartAtSpawn();

        currentSpeed = 0.0f;
        forwardSpeed = 0.3f;
        brakeSpeed = 0.5f;
        coastToStopSpeed = 0.35f;
        maxSpeed = 1.0f;

        backwardSpeed = -0.1f;

        currentTurnAngle = 0.0f;
        turnAngleRate = 2.0f;
        maxTurnAngle = 8.0f;

        scootersRigidbodyComponent = gameObject.GetComponent<Rigidbody>();
        if (scootersRigidbodyComponent == null)
        {
            Debug.Log("Scooter setup incorrectly, no rigidbody found");
        }
    }

    public void RestartAtSpawn()
    {
        transform.position = restartAt.position;
        transform.rotation = restartAt.rotation;

        stopScooterMovement();
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
         //   bikeModel.transform.Rotate(Vector3.right * Time.deltaTime);
            currentTurnAngle += Time.deltaTime * turnAngleRate * Input.GetAxisRaw("Horizontal");
            if (currentTurnAngle > maxTurnAngle)
            {
                currentTurnAngle = maxTurnAngle;
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
          //  bikeModel.transform.Rotate(-Vector3.right * Time.deltaTime);
            currentTurnAngle += Time.deltaTime * turnAngleRate * Input.GetAxisRaw("Horizontal");
            if (currentTurnAngle < -maxTurnAngle)
            {
                currentTurnAngle = -maxTurnAngle;
            }
        }
        if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {
            currentTurnAngle = 0;
           // bikeModel.transform.rotation = Quaternion.Euler(0,-90,0);
        }

        //brake
        if (Input.GetKey(KeyCode.Space))
        {
            currentSpeed += brakeSpeed * Input.GetAxisRaw("Vertical");
            if (currentSpeed < 0)
            {
                brakeLights.SetActive(true);
                currentSpeed = backwardSpeed;
            }
            else
            {
                brakeLights.SetActive(false);
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (currentSpeed < 0)
            {
                brakeLights.SetActive(false);
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
}
