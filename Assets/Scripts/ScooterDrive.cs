using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class ScooterDrive : MonoBehaviour
{

    PlayerControls controls;

    //this variable is used to determine how much force to apply to enviornment objects after collision
    public static float playerCurrentSpeed;
    public static float maxSpeed = 40f;

    public float currentSpeed;
    public float forwardSpeed = 100f;
    public float backwardSpeed = -10.1f;
    public bool backingUp = false;
    public float coastToStopSpeed = 0.35f;

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

    public float brakeSpeed = 15f;

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

    public GameObject collisionParticle;
    public float speedPenaltyPercent = 15;

    public GameObject physicalOrder;

    public GameObject TotalScore, star1, star2, star3, star4, star5;
    public double star2threshold = .2;
    public double star3threshold = .4;
    public double star4threshold = .6;
    public double star5threshold = .8;
    public RatingsManager ratingsManager;

	public AudioClip bikeIdleAudioClip, bikeAccelleratingAudioClip, bikeLetOffGasAudioClip, bikeTopSpeedClip;
	private AudioSource bikeIdleAudioSource, bikeAccelleratingAudioSource, bikeLetOffGasAudioSource, bikeTopSpeedAudioSource;

	public GameObject textTip;

    bool canBeCollided;
    public float collisionPercent;
    public GameObject bike, playerModel;

    //Input Controls
    private bool isAccelerating;

    private void Awake()
    {
        controls = new PlayerControls();

        controls.GamePlay.Accelerate.performed += context => isAccelerating = true;
        controls.GamePlay.Accelerate.canceled += context => isAccelerating = false;
    }

    private void OnEnable()
    {
        controls.GamePlay.Enable();
    }

    private void OnDisable()
    {
        controls.GamePlay.Disable();
    }

    void Start()
    {
        //RestartAtSpawn();

        scootersRigidbodyComponent = gameObject.GetComponent<Rigidbody>();
        if (scootersRigidbodyComponent == null)
        {
            Debug.Log("Scooter setup incorrectly, no rigidbody found");
        }

		bikeIdleAudioSource = AudioManager.Instance.PlaySoundSFX(bikeIdleAudioClip, gameObject, loop: true, volume: 0.1f);
		bikeAccelleratingAudioSource = AudioManager.Instance.PlaySoundSFX(bikeAccelleratingAudioClip, gameObject, loop: true, volume: 0.25f);
		bikeAccelleratingAudioSource.Stop();
		bikeLetOffGasAudioSource = AudioManager.Instance.PlaySoundSFX(bikeLetOffGasAudioClip, gameObject, loop: true, volume: 0.5f);
		bikeLetOffGasAudioSource.Stop();
		bikeLetOffGasAudioSource.loop = false;
		bikeTopSpeedAudioSource = AudioManager.Instance.PlaySoundSFX(bikeTopSpeedClip, gameObject, loop: true, volume: 0.5f);
		bikeTopSpeedAudioSource.Stop();

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
            phoneToggle = !phoneToggle;
            textTip.SetActive(phoneToggle == false);
            PhoneActivation();
        }

        playerCurrentSpeed = currentSpeed;

        previousX = gameObject.transform.position.x;
        previousZ = gameObject.transform.position.z;

        if (bikeLetOffGasAudioSource.time == bikeLetOffGasAudioSource.clip.length)
        {
            bikeLetOffGasAudioSource.time = 0;
            bikeIdleAudioSource.Play();
        }

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

    void accelerate()
    {

        currentSpeed += forwardSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical");
        /*if (currentSpeed > maxSpeed)
        {
            currentSpeed = maxSpeed;
            //if (bikeAccelleratingAudioSource.isPlaying && bikeAccelleratingAudioSource.time == bikeAccelleratingAudioSource.clip.length)
            //{

            //if (bikeTopSpeedAudioSource.isPlaying == false)
            //{
            //     bikeAccelleratingAudioSource.Stop();
            //     bikeTopSpeedAudioSource.Play();
            // }

            //}
        }

        if (!bikeAccelleratingAudioSource.isPlaying && currentSpeed < maxSpeed)
        {
            bikeIdleAudioSource.Stop();
            bikeAccelleratingAudioSource.Play();
        }*/
    }

    void HandleControlKeys()
    {
        //forward and backwards
        if (Input.GetKey(KeyCode.Space))
        {
            currentSpeed += forwardSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical");
            if (currentSpeed > 1.25f)
            {
                currentSpeed = 1.25f;
                //if (bikeAccelleratingAudioSource.isPlaying && bikeAccelleratingAudioSource.time == bikeAccelleratingAudioSource.clip.length)
                //{
                    
                //if (bikeTopSpeedAudioSource.isPlaying == false)
                //{
               //     bikeAccelleratingAudioSource.Stop();
               //     bikeTopSpeedAudioSource.Play();
               // }
                    
                //}
            }

            if (!bikeAccelleratingAudioSource.isPlaying && currentSpeed < maxSpeed)
            {
                bikeIdleAudioSource.Stop();
                bikeAccelleratingAudioSource.Play();
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
        

        //let off gas sfx
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (bikeAccelleratingAudioSource.isPlaying)
            {
                bikeAccelleratingAudioSource.Stop();
            }
            else if (bikeTopSpeedAudioSource.isPlaying)
            {
                bikeTopSpeedAudioSource.Stop();
            }
            
            bikeLetOffGasAudioSource.Play();
        }

        //turns
        if (Input.GetKey(KeyCode.D))
        {
            if (maxLeftTurnHeld || maxRightTurnHeld)
            {
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
            currentTurnAngle += Time.deltaTime * turnAngleRate * Input.GetAxisRaw("Horizontal") * 3;
            if (currentTurnAngle > maxTurnAngle)
            {
                currentTurnAngle = maxTurnAngle;
            }
        }
        
        if (Input.GetKey(KeyCode.A))
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
            currentTurnAngle += Time.deltaTime * turnAngleRate * Input.GetAxisRaw("Horizontal") * 3;
            if (currentTurnAngle < -maxTurnAngle)
            {
                currentTurnAngle = -maxTurnAngle;
            }
        }
        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
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

        if (currentSpeed == 0 && !bikeIdleAudioSource.isPlaying)
        {
            bikeAccelleratingAudioSource.Stop();
            bikeIdleAudioSource.Play();
        }

        //brake
        if ( (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.K)) && Input.GetKey(KeyCode.Space))
        {
            currentSpeed += brakeSpeed * Input.GetAxisRaw("Vertical") * 3;
            if (currentSpeed < 0)
            {
                //brakeLights.SetActive(true);
                //currentSpeed = backwardSpeed;
                currentSpeed = 0;
            }
            else
            {
                //brakeLights.SetActive(false);
            }
        }
        else if ( (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.K) ) && !Input.GetKey(KeyCode.Space))
        {
            if (currentSpeed < 0 && !backingUp)
            {
                Debug.Log("inside current speed less than 0 check");
                currentSpeed = 0;
                return;
            }
            else if (currentSpeed > 0 && !backingUp)
            {
                currentSpeed += (brakeSpeed / 12) * Input.GetAxisRaw("Vertical") * 3;
                
                return;
            }

            if (backingUp)
            {
                Debug.Log("inside backing up check");
                currentSpeed = backwardSpeed;
                return;
            }

            brakeLights.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.K) && currentSpeed == 0 && !Input.GetKey(KeyCode.Space))
        {
            backingUp = true;
        }
        if (Input.GetKeyUp(KeyCode.K))
        {
            backingUp = false;
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
        if (Input.GetKey(KeyCode.LeftShift) == false && Input.GetKey(KeyCode.Space) == false && Input.GetKey(KeyCode.S) == false)
        {
            currentSpeed -= Time.deltaTime * coastToStopSpeed * 2;
            if (currentSpeed < 0)
            {
                currentSpeed = 0;
            }
        }

        if (isAccelerating)
        {
            accelerate();
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
            GameManager.player1OrderPickedUp = true;
            physicalOrder.SetActive(true);
        }

        if (other.tag == "AICar" && canBeCollided)
        {
            print("playerFallsOffBike");
            currentSpeed = 0;
            playerModel.GetComponent<Rigidbody>().AddForce(transform.up * bikeCrashWithAICarBumbForce, ForceMode.Impulse);
            canBeCollided = false;
            StartCoroutine(FallingOffBike());
        }

        if (other.tag == "WayPointCustomer")
        {
            if (GameManager.player1OrderPickedUp)
            {
                GameManager.player1OrderDelivered = true;
                physicalOrder.SetActive(false);

                //food health / 100
                float tempFoodHealthScore = FoodHealth.currentHealth / 100;
                //time remaining / total time
                float tempTimeScore = DashAppScript.totalTimeRemaining;
                // (% + %) / 2
                float tempTotalScore = (tempFoodHealthScore + tempTimeScore) / 2;

                //total score displayed in stars
                GameManager.player1ScoreOnOrder = tempTotalScore;
                int starsAwarded = 0;
                
                //total score added to macrototal score
                TotalScore.SetActive(true);
                if (GameManager.player1ScoreOnOrder < star2threshold)
                {
                    star1.SetActive(true);
                    starsAwarded++;
                }
                if (GameManager.player1ScoreOnOrder < star3threshold)
                {
                    star2.SetActive(true);
                    starsAwarded++;
                }
                if (GameManager.player1ScoreOnOrder < star4threshold)
                {
                    star3.SetActive(true);
                    starsAwarded++;
                }
                if (GameManager.player1ScoreOnOrder < star5threshold)
                {
                    star4.SetActive(true);
                    starsAwarded++;
                }
                if (GameManager.player1ScoreOnOrder > star5threshold)
                {
                    star5.SetActive(true);
                    starsAwarded++;
                }
                
                var rating = ratingsManager.CreateRating(starsAwarded);
                ratingsManager.AddRating(rating);

                print(GameManager.player1ScoreOnOrder);

                StartCoroutine(Waiting());
                //display score
                //turn off player1OrderPickedUp and player1OrderDelivered
                //turn off waypoint boxes
                //close app line for the order
            }
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
}
