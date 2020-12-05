using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScooterDrive : MonoBehaviour
{
    //this variable is used to determine how much force to apply to enviornment objects after collision
    public static float playerCurrentSpeed;

    public float currentSpeed;
    public float forwardSpeed = 0.3f;
    public float backwardSpeed = -.1f;
    public float coastToStopSpeed = 0.35f;
    public float maxSpeed = 2.0f;

    public float currentTurnAngle = 0;
    public float turnAngleRate = 2f;
    public float maxTurnAngle = 15f;

    public float brakeSpeed = 0.5f;

    public GameObject brakeLights;

    public Transform restartAt;
    Rigidbody scootersRigidbodyComponent;

    public GameObject bikeModel;

    public Animator phone;
    bool phoneToggle;

    public static bool isMovingNorth = false;
    public static bool isMovingEast = false;
    public static bool isMovingSouth = false;
    public static bool isMovingWest = false;

    public float previousX;// east/west
    public float previousZ;// north/south


    // Start is called before the first frame update
    void Start()
    {
        //RestartAtSpawn();

        scootersRigidbodyComponent = gameObject.GetComponent<Rigidbody>();
        if (scootersRigidbodyComponent == null)
        {
            Debug.Log("Scooter setup incorrectly, no rigidbody found");
        }
    }


    // Update is called once per frame
    void Update()
    {
        
        HandleControlKeys();
        MoveBikeForwardOrBackward();
        TurnBikeLeftOrRight();

        updateDirectionBools();

        if (Input.GetKeyDown(KeyCode.C))
        {
            phoneToggle = !phoneToggle;
            PhoneActivation();
        }

        playerCurrentSpeed = currentSpeed;

        previousX = gameObject.transform.position.x;
        previousZ = gameObject.transform.position.z;

    }// end of update(){}

    public void updateDirectionBools()
    {
        if (gameObject.transform.position.z > previousZ)
        {
            isMovingNorth = true;
            isMovingSouth = false;
        }
        else 
        {
            isMovingSouth = true;
            isMovingNorth = false;
        }

        if (gameObject.transform.position.x > previousX)
        {
            isMovingWest = false;
            isMovingEast = true;
        }
        else
        {
            isMovingWest = true;
            isMovingEast = false;
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
        if (Input.GetKey(KeyCode.Space))
        {
            currentSpeed += forwardSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical");
            if (currentSpeed > maxSpeed)
            {
                currentSpeed = maxSpeed;
            }
        }
        else if (!Input.GetKey(KeyCode.Space) && currentSpeed > 0)
        {
            currentSpeed += Time.deltaTime * brakeSpeed * Input.GetAxisRaw("Vertical");
            if (currentSpeed < 0)
            {
                currentSpeed = 0;
            }
        }
        if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.Space))
        {
            currentSpeed -= Time.deltaTime * backwardSpeed;
        }

        //turns
        if (Input.GetKey(KeyCode.D))
        {
         //   bikeModel.transform.Rotate(Vector3.right * Time.deltaTime);
            currentTurnAngle += Time.deltaTime * turnAngleRate * Input.GetAxisRaw("Horizontal");
            if (currentTurnAngle > maxTurnAngle)
            {
                currentTurnAngle = maxTurnAngle;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
          //  bikeModel.transform.Rotate(-Vector3.right * Time.deltaTime);
            currentTurnAngle += Time.deltaTime * turnAngleRate * Input.GetAxisRaw("Horizontal");
            if (currentTurnAngle < -maxTurnAngle)
            {
                currentTurnAngle = -maxTurnAngle;
            }
        }
        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            currentTurnAngle = 0;
           // bikeModel.transform.rotation = Quaternion.Euler(0,-90,0);
        }

        //brake
        if ( (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.K)) && Input.GetKey(KeyCode.Space))
        {
            currentSpeed += brakeSpeed * Input.GetAxisRaw("Vertical");
            if (currentSpeed < 0)
            {
                //brakeLights.SetActive(true);
                currentSpeed = backwardSpeed;
            }
            else
            {
                //brakeLights.SetActive(false);
            }
        }
        else if ( (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.K)) && !Input.GetKey(KeyCode.Space))
        {
            currentSpeed += (brakeSpeed/12) * Input.GetAxisRaw("Vertical");
            brakeLights.SetActive(true);
            if (currentSpeed < 0)
            {
                //brakeLights.SetActive(true);
                currentSpeed = backwardSpeed;
            }
            else
            {
                //brakeLights.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.K))
        {
            brakeLights.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.K))
        {
                brakeLights.SetActive(false);   
        }

        //coasting to stop
        if (Input.GetKey(KeyCode.LeftShift) == false && Input.GetKey(KeyCode.Space) == false)
        {
            currentSpeed -= Time.deltaTime * coastToStopSpeed;
            if (currentSpeed < 0)
            {
                currentSpeed = 0;
            }
        }
    }

    void PhoneActivation()
    {
        if (phoneToggle)
        {
            phone.SetBool("PhoneOn", true);
        }

        if (!phoneToggle)
        {
            phone.SetBool("PhoneOn", false);
        }
    }
}
