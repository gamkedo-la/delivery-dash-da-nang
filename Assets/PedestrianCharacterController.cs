using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianCharacterController : MonoBehaviour
{
    public Vector3 destination;
    Vector3 lastPosition;
    public bool reachedDestination;
    public float stopDistance = 1;
    public float rotationSpeed;
    public float minSpeed, maxSpeed;
    public float movementSpeed;
    Vector3 velocity;

    public bool isCar;
    bool hasCollided;

    private bool hasScreamedThisCollision = false;
    
    public AudioClip danielleScreamAudioClip, scream2, scream3, scream4;
    public List<AudioClip> listOfScreams = new List<AudioClip>(4);
    //balal;kgha;oirghoiwrjg

    private void Start()
    {
        movementSpeed = Random.Range(minSpeed, maxSpeed);
    }
    private void Update()
    {
        if (!hasCollided)
        {
            if (transform.position != destination)
            {
                Vector3 destinationDirection = destination - transform.position;
                destinationDirection.y = 0;

                float destinationDistance = destinationDirection.magnitude;

                if (destinationDistance >= stopDistance)
                {
                    reachedDestination = false;
                    Quaternion targetRotation = Quaternion.LookRotation(destinationDirection);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                    transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
                }
                else
                {
                    reachedDestination = true;
                }

                velocity = (transform.position - lastPosition) / Time.deltaTime;
                velocity.y = 0;
                var velocityMagnitude = velocity.magnitude;
                velocity = velocity.normalized;
                var fwdDotProduct = Vector3.Dot(transform.forward, velocity);
                var rightDotProduct = Vector3.Dot(transform.right, velocity);
            }

            else
            {
                reachedDestination = true;
            }
        }
    }

    public void SetDestination(Vector3 destination)
    {
        this.destination = destination;
        reachedDestination = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !isCar)
        {
            if (!hasScreamedThisCollision)
            {
                playRandomScream();
            }

            if (isCar)
            {
                print("im colliding now");
                hasCollided = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && isCar)
        {
           hasCollided = false;
        }
    }



    private void playRandomScream()
    {
        var randomScreamListIndex = Random.Range(0, listOfScreams.Count);
        Debug.Log("randomScreamListIndex: " + randomScreamListIndex);
        AudioManager.Instance.PlaySoundSFX(listOfScreams[randomScreamListIndex], gameObject, volume: 0.5f);
        hasScreamedThisCollision = true;

        StartCoroutine(delayPotentialForSecondScream());
    }

    IEnumerator delayPotentialForSecondScream()
    {
        yield return new WaitForSeconds(1);

        hasScreamedThisCollision = false;
    }
}
