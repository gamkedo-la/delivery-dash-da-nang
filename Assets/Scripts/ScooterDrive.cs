using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Linq;
using System;

public class ScooterDrive : MonoBehaviour
{

    PlayerControls controls;

    public bool player1, player2, player3, player4;

    public GameObject[] playerCharacter;

    //this variable is used to determine how much force to apply to enviornment objects after collision
    public static float playerCurrentSpeed;
    public static float maxSpeed = 15f;

    public float currentSpeed;
    public float forwardSpeed = 0.001f;
    public float backwardSpeed = -10.1f;
    public bool backingUp = false;
    public float coastToStopSpeed = 0.25f;

    public float currentTurnAngle = 0;
    public float turnAngleRate = 150f;
    public float maxTurnAngle = 1000f;

    public float maxTiltAngle = 45f;
    public float currentBikeTiltAngle = 0.0f;
    bool maxRightTurnHeld = false;
    bool maxLeftTurnHeld = false;

    public float bikeStraightenSpeed = 60f;
    public float bikeMaxTiltAngle = 0.02f;
    public float bikeCrashWithAICarBumbForce = 5.0f;

    public float brakeSpeed = 0;
    public float brakeMaxSpeed = 15f;
    private float brakeAccelerating = 0.025f; //Change this if you want to tweak braking.

    public GameObject brakeLights;

    public Transform restartAt;
    Rigidbody scootersRigidbodyComponent;

    public GameObject bikeModel;

    public Animator phone;
    static bool phoneToggle;

    public static bool isMovingNorth = false;
    public static bool isMovingEast = false;
    public static bool isMovingSouth = false;
    public static bool isMovingWest = false;

    public float previousX;// east/west
    public float previousZ;// north/south

    public GameObject collisionParticle;
    public float speedPenaltyPercent = 15;

    public GameObject physicalOrder;

    public GameObject TotalScore, star1, star2, star3, star4, star5;
    public double star2threshold = 20;
    public double star3threshold = 50;
    public double star4threshold = 70;
    public double star5threshold = 85;
    public RatingsManager ratingsManager;
    public AudioClip bikeIdleAudioClip, bikeAccelleratingAudioClip, bikeLetOffGasAudioClip, bikeTopSpeedClip, phoneInOutAudioClip;
    private AudioSource bikeCurrentAudioSource;

	public GameObject textTip;

    bool canBeCollided;
    public float collisionPercent;
    public GameObject bike, playerModel;

    //Input Controls
    public int playerIndex = 0;

    public bool isAccelerating = false;
    public bool acceleratingCompleted = false;
    public bool turnLeft = false;
    public bool turnRight = false;
    public bool isBraking = false;
    public bool isBrakingCompleted = false;
    public bool isReversing = false;
    public bool isReversingCompleted = false;
    public int accelerateValue;

    private GameObject homeScreen;
    public bool phoneActive = false;

    DeliveryDriver driverID;

    private void Awake()
    {
        //homeScreen = GameObject.Find("HomeScreen");
        

        //controls = new PlayerControls();

        //controls.GamePlay.Accelerate.performed += context => { isAccelerating = true; };
        //controls.GamePlay.Accelerate.canceled += context => { isAccelerating = false; acceleratingCompleted = true; };
        ////controls.GamePlay.AccelerateStick.performed += context =>
        ////{
        ////        isAccelerating = true; 
        ////        isAcceleratingFromStick = true;
        ////        acceleratingCompleted = false;
        ////};
        ////controls.GamePlay.AccelerateStick.canceled += context => { isAccelerating = false; acceleratingCompleted = true; isAcceleratingFromStick = false; };
        //controls.GamePlay.TurnLeft.performed += context => { /*Debug.Log("left stick recognized");*/ turnLeft = true;  } ;
        //controls.GamePlay.TurnLeft.canceled += context => { /*Debug.Log("left stick recognized");*/ turnLeft = false; };
        //controls.GamePlay.TurnRight.performed += context => { /*Debug.Log("left stick recognized");*/ turnRight = true; };
        //controls.GamePlay.TurnRight.canceled += context => { /*Debug.Log("left stick recognized");*/ turnRight = false; };
        //controls.GamePlay.Brake.performed += context => { /*Debug.Log("right trigger is recognized");*/ isBraking = true; };
        //controls.GamePlay.Brake.canceled += context => { isBraking = false; isBrakingCompleted = true; };
        //controls.GamePlay.PhoneOutIn.performed += context => { PhoneOutIn(); };

        //controls.GamePlay.navigateUIUp.performed += context => {
        //    HandleNavigateUIUp();
        //};

        //controls.GamePlay.navigateUIRight.performed += context => {
        //    HandleNavigateUIRight();
        //};

        //controls.GamePlay.navigateUIDown.performed += context => {
        //    HandleNavigateUIDown();
        //};

        //controls.GamePlay.navigateUILeft.performed += context => {
        //    HandleNavigateUILeft();
        //};
    }

    private void OnEnable()
    {
        //controls.GamePlay.Enable();
    }

    private void OnDisable()
    {
        //controls.GamePlay.Disable();
    }

    void Start()
    {
        //RestartAtSpawn();
        driverID = GetComponent<DeliveryDriver>();

        scootersRigidbodyComponent = gameObject.GetComponent<Rigidbody>();
        if (scootersRigidbodyComponent == null)
        {
            Debug.Log("Scooter setup incorrectly, no rigidbody found");
        }

		bikeCurrentAudioSource = AudioManager.Instance.PlaySoundSFX(bikeIdleAudioClip, gameObject, loop: true, volume: 0.1f);

        if (player1)
        {
            playerCharacter[MainMenu.player1Character].SetActive(true);
        }
        if (player2)
        {
            playerCharacter[MainMenu.player2Character].SetActive(true);
        }
        if (player3)
        {
            playerCharacter[MainMenu.player3Character].SetActive(true);
        }
        if (player4)
        {
            playerCharacter[MainMenu.player4Character].SetActive(true);
        }
    }

    public void PhoneOutIn()
    {
        AudioManager.Instance.PlaySoundSFX(phoneInOutAudioClip, gameObject);
        phoneToggle = !phoneToggle;
        textTip.SetActive(phoneToggle == false);
        PhoneActivation();
    }

    // Update is called once per frame
    void Update()
    {
        
        HandleControlKeys();
        MoveBikeForwardOrBackward();
        TurnBikeLeftOrRight();
        if (currentTurnAngle != 0)
        {
            
        }
        updateDirectionBools();

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (player1)
            {
                PhoneOutIn();
            }
        }

        playerCurrentSpeed = currentSpeed;

        previousX = gameObject.transform.position.x;
        previousZ = gameObject.transform.position.z;

        if (currentSpeed >= ((collisionPercent / 100) * maxSpeed))
        {
            canBeCollided = true;
        }

        else
        {
            canBeCollided = false;
        }
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
        scootersRigidbodyComponent.angularVelocity = Vector3.zero;
        currentSpeed = 0.0f;
        currentTurnAngle = 0.0f;
    }

    void MoveBikeForwardOrBackward()
    {
        transform.position += transform.forward * currentSpeed * 3;
    }

    void TurnBikeLeftOrRight()
    {
        if (currentTurnAngle != 0)
        {
            transform.Rotate(Vector3.up, currentTurnAngle);
            
        }
    }

    /*void Accelerate()
    {
        currentSpeed += forwardSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical");
        if (currentSpeed > maxSpeed)
        {
            currentSpeed = maxSpeed;
            if (bikeCurrentAudioSource.clip != bikeTopSpeedClip) {
				AudioManager.Instance.StopSound(bikeCurrentAudioSource);
				bikeCurrentAudioSource = AudioManager.Instance.PlaySoundSFX(bikeTopSpeedClip, gameObject, loop: true, volume: 0.25f);
            }
        }
		else if (currentSpeed < maxSpeed && bikeCurrentAudioSource.clip != bikeAccelleratingAudioClip) {
			AudioManager.Instance.StopSound(bikeCurrentAudioSource);
			bikeCurrentAudioSource = AudioManager.Instance.PlaySoundSFX(bikeAccelleratingAudioClip, gameObject, loop: true, volume: 0.25f);
		}
    }*/

    void HandleControlKeys()
    {
        if (isAccelerating && (isReversing || isBraking))
        {
            accelerateValue = 1;
        }
        else if (isAccelerating)
        {
            //accelerateValue = 1;
        }
        else if (!isAccelerating && (isReversing || isBraking))
        {
            accelerateValue = -1;
        }
        else
        {
            accelerateValue = 0;
        }

        if (isBraking)
        {
            brakeSpeed += brakeAccelerating * Time.deltaTime;

            if (brakeSpeed > brakeMaxSpeed)
            {
                brakeSpeed = brakeMaxSpeed;
            }
        }
        else
        {
            brakeSpeed = 0.0f;
        }

        if (isBraking && currentSpeed == 0)
        {
            isReversing = true;
            isReversingCompleted = false;
        }
        else if (!isBraking && isReversing )
        {
            isReversing = false;
            isReversingCompleted = true;
        }

        //forward and backwards
        if (isAccelerating)
        {

            currentSpeed += /*forwardSpeed */ 0.2f * Time.deltaTime /* * (accelerateValue) */; 
            //Debug.Log("current speed: " + currentSpeed);
            if (currentSpeed > 0.45f)
            {
                currentSpeed = 0.45f;
                //** BELOW TO BE USED WHEN WE HAVE A BETTER TOP SPEED SOUND
				/*if (bikeCurrentAudioSource.clip != bikeTopSpeedClip) 
				{
					AudioManager.Instance.StopSound(bikeCurrentAudioSource);
					bikeCurrentAudioSource = AudioManager.Instance.PlaySoundSFX(bikeTopSpeedClip, gameObject, loop: true, volume: 0.25f);
				}*/
			}
			else if (currentSpeed < 1.25f && bikeCurrentAudioSource.clip != bikeAccelleratingAudioClip) 
			{
				AudioManager.Instance.StopSound(bikeCurrentAudioSource);
				bikeCurrentAudioSource = AudioManager.Instance.PlaySoundSFX(bikeAccelleratingAudioClip, gameObject, loop: true, volume: 0.25f);
			}

            //if (currentSpeed > maxSpeed)
            //{
             //   currentSpeed = maxSpeed;
            //}    
		}
        else if (!isAccelerating && currentSpeed > 0)
        {
            currentSpeed += Time.deltaTime * brakeSpeed * accelerateValue;
            if (currentSpeed < 0)
            {
                currentSpeed = 0;
            }
        }
        

        //let off gas sfx
        if (acceleratingCompleted)
        {
			AudioManager.Instance.StopSound(bikeCurrentAudioSource);
			bikeCurrentAudioSource = AudioManager.Instance.PlaySoundSFX(bikeIdleAudioClip, gameObject, loop: true, volume: 0.1f);
			AudioManager.Instance.PlaySoundSFX(bikeLetOffGasAudioClip, gameObject, volume: 0.25f);

			acceleratingCompleted = false;
        }

        //turns
        if (turnRight)
        {
            if (maxLeftTurnHeld || maxRightTurnHeld)
            {
                Debug.Log("maxTurnReached");
                return;
            }

            //Debug.Log("bikeModel.transform.localRotation: " + bikeModel.transform.localRotation);

            currentBikeTiltAngle = bikeModel.transform.localRotation.z;
            if (currentBikeTiltAngle < (-maxTiltAngle))
            {
                bikeModel.transform.localRotation = Quaternion.Euler(0, 0, currentBikeTiltAngle*100);
                maxRightTurnHeld = true;
            }

            bikeModel.transform.Rotate(-Vector3.forward * Time.deltaTime * 20);

            //Debug.Log("currentTurnAngle: " + currentTurnAngle);
            currentTurnAngle += Time.deltaTime * turnAngleRate;
            if (currentTurnAngle > maxTurnAngle)
            {
                currentTurnAngle = maxTurnAngle;
            }
        }
        
        if (turnLeft)
        {
            if (maxLeftTurnHeld || maxRightTurnHeld)
            {
                return;
            }

            //Debug.Log("bikeModel.transform.localRotation: " + bikeModel.transform.localRotation);
            //Debug.Log("bikeTiltAngle: " + bikeModel.transform.localRotation.z);

            currentBikeTiltAngle = bikeModel.transform.localRotation.z;
            if (currentBikeTiltAngle > (maxTiltAngle))
            {
                bikeModel.transform.localRotation = Quaternion.Euler(0, 0, currentBikeTiltAngle * 100);
                maxLeftTurnHeld = true;
            }

            bikeModel.transform.Rotate(Vector3.forward * Time.deltaTime * 20);

            // Debug.Log("currentTurnAngle: " + currentTurnAngle);
            currentTurnAngle += -Time.deltaTime * turnAngleRate;
            if (currentTurnAngle < -maxTurnAngle)
            {
                currentTurnAngle = -maxTurnAngle;
            }
        }
        if (!turnRight && !turnLeft)
        {
            maxRightTurnHeld = false;
            maxLeftTurnHeld = false;

            currentTurnAngle = 0;
            //Debug.Log("bikeModel.transform.localRotation: " + bikeModel.transform.localRotation);
            if (bikeModel.transform.localRotation.z > 0)
            {
                bikeModel.transform.Rotate(Vector3.forward * Time.deltaTime * -bikeStraightenSpeed);
            }
            else if (bikeModel.transform.localRotation.z < 0)
            {
                bikeModel.transform.Rotate(Vector3.forward * Time.deltaTime * bikeStraightenSpeed);
            }

            //Debug.Log("currentTurnAngle: " + currentTurnAngle);
            if ( bikeModel.transform.localRotation.z < bikeMaxTiltAngle && bikeModel.transform.localRotation.z > -bikeMaxTiltAngle)
            {
                //Debug.Log("local rotation being manipulated");
                // bikeModel.transform.localRotation = Quaternion.Euler(0, 0, 0.0f);
                bikeModel.transform.localRotation = Quaternion.identity;
            }

        }

        if (currentSpeed == 0 && bikeCurrentAudioSource.clip != bikeIdleAudioClip) {
			AudioManager.Instance.StopSound(bikeCurrentAudioSource);
			bikeCurrentAudioSource = AudioManager.Instance.PlaySoundSFX(bikeIdleAudioClip, gameObject, loop: true, volume: 0.1f);
		}

		//brake
		if (isBraking && isAccelerating)
        {
            //brakeSpeed is currently 0.025f * Time.deltaTime 
            currentSpeed += brakeSpeed * currentSpeed;
            if (currentSpeed < 0)
            {
                currentSpeed = 0;
            }
        }
        else if (isBraking && !isAccelerating)
        {
            currentSpeed += brakeSpeed * accelerateValue * 3;
            if (currentSpeed < 0)
            {
                //Debug.Log("inside current speed less than 0 check");
                currentSpeed = 0;
                isBrakingCompleted = true;
                return;
            }

            brakeLights.SetActive(true);
        }

        if (backingUp)
        {
            //Debug.Log("inside backing up check");
            currentSpeed = backwardSpeed;
            brakeLights.SetActive(true);
            return;
        }

        if (isReversing && currentSpeed == 0 && !isAccelerating)
        {
            backingUp = true;
        }
        if (isReversingCompleted)
        {
            backingUp = false;
        }

        if (isBraking || isReversing)
        {
            brakeLights.SetActive(true);
        }
        if (isBrakingCompleted || isReversingCompleted)
        {
            brakeLights.SetActive(false);
        }

        //coasting to stop
        if ((!isBraking && !isAccelerating && !isReversing))
        {
            currentSpeed -= Time.deltaTime * coastToStopSpeed;
            if (currentSpeed < 0)
            {
                currentSpeed = 0;
            }
        }

        //if (isAccelerating)
        //{
        //    accelerate();
        //}
    }

    void PhoneActivation()
    {
        if (phoneToggle)
        {
            phone.SetBool("PhoneOn", true);
            phoneActive = true;
        }

        if (!phoneToggle)
        {
            phone.SetBool("PhoneOn", false);
            phoneActive = false;
        }
    }

    void CheckIfPhoneIsActive()
    {
        Debug.Log(phone.GetBool("PhoneOn"));
    }

    public void AssignStars()
    {
        if (player1)
        {
            GameManager.player1OrderDelivered = true;
        }
        if (player2)
        {
            GameManager.player2OrderDelivered = true;
        }
        if (player3)
        {
            GameManager.player3OrderDelivered = true;
        }
        if (player4)
        {
            GameManager.player4OrderDelivered = true;
        }
        physicalOrder.SetActive(false);

        float tempScore = (driverID.scoreOnOrder + FoodHealth.currentHealth) / 2;

        int starsAwarded = 0;

        //total score added to macrototal score
        TotalScore.SetActive(true);
        if (tempScore < star2threshold && tempScore > 0)
        {
            star1.SetActive(true);
            starsAwarded++;
        }
        if (tempScore > star2threshold)
        {
            star2.SetActive(true);
            starsAwarded++;
        }
        if (tempScore > star3threshold)
        {
            star3.SetActive(true);
            starsAwarded++;
        }
        if (tempScore > star4threshold)
        {
            star4.SetActive(true);
            starsAwarded++;
        }
        if (tempScore > star5threshold)
        {
            star5.SetActive(true);
            starsAwarded++;
        }
        print(tempScore + ":" + driverID.scoreOnOrder + "+" + FoodHealth.currentHealth);

        var rating = ratingsManager.CreateRating(starsAwarded);
        ratingsManager.AddRating(rating);

        StartCoroutine(Waiting());
        //display score
        //turn off player1OrderPickedUp and player1OrderDelivered
        //turn off waypoint boxes
        //close app line for the order
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DestEnv")
        {
            Instantiate(collisionParticle, other.gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position), transform.rotation);
            playerCurrentSpeed -= speedPenaltyPercent;
            FoodHealth.currentHealth -= 5f;
            //print(playerCurrentSpeed);
        }

        if (other.tag == "WayPointBox")
        {
            if (player1)
            {
                GameManager.player1OrderPickedUp = true;
            }
            if (player2)
            {
                GameManager.player2OrderPickedUp = true;
            }
            if (player3)
            {
                GameManager.player3OrderPickedUp = true;
            }
            if (player4)
            {
                GameManager.player4OrderPickedUp = true;
            }
            physicalOrder.SetActive(true);
        }

        if (other.tag == "Building")
        {
            currentSpeed = 0;
        }

        if (other.tag == "Pedestrian")
        {
            currentSpeed = 0;
            FoodHealth.currentHealth -= 5f;
        }

        if (other.tag == "AICar")
        {
            FoodHealth.currentHealth -= 5f;
            currentSpeed = 0;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "AICar")
        {
            currentSpeed = 0;
        }
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(2);
        TotalScore.SetActive(false);
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
        star4.SetActive(false);
        star5.SetActive(false);
    }

    IEnumerator FallingOffBike()
    {
        yield return new WaitForSeconds(1);
        playerModel.transform.localPosition = new Vector3(0.1207f, 0f, .6239f);
        playerModel.transform.localRotation = Quaternion.identity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "building")
        {
            
            currentSpeed = 0;
        }
    }

    public void HandleNavigateUIUp()
    {
        homeScreen.GetComponent<HomeScreenScript>().dPadUpPressed = true;
        homeScreen.GetComponent<HomeScreenScript>().handleGamepadUINavigation(); 
        CheckIfPhoneIsActive();
    }

    public void HandleNavigateUIDown()
    {
        homeScreen.GetComponent<HomeScreenScript>().dPadDownPressed = true;
        homeScreen.GetComponent<HomeScreenScript>().handleGamepadUINavigation(); 
        CheckIfPhoneIsActive();
    }

    public void HandleNavigateUILeft()
    {
        homeScreen.GetComponent<HomeScreenScript>().dPadLeftPressed = true;
        homeScreen.GetComponent<HomeScreenScript>().handleGamepadUINavigation(); 
        CheckIfPhoneIsActive();
    }

    public void HandleNavigateUIRight()
    {
        homeScreen.GetComponent<HomeScreenScript>().dPadRightPressed = true;
        homeScreen.GetComponent<HomeScreenScript>().handleGamepadUINavigation();
        CheckIfPhoneIsActive();
    }
}
