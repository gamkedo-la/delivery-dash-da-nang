using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAI : MonoBehaviour
{
    Transform[] Restaurants;
    Transform[] Apartments;

    Transform apartmentToGoTo;
    Transform restaurantToGoTo;

    bool orderSelected;
    bool orderPickedUp;
    bool orderDelivered;

    public NavMeshAgent agent;
    float dist;

    public GameObject target;

    Rigidbody rb;
    Vector3 previousPosition;
    float curSpeed;

    public GameObject toGoBox;

    public float orderScore;

    public bool enemy2, enemy3, enemy4;

    public float enemyScore;

    void Start() {

        rb = GetComponent<Rigidbody>(); 

        Restaurants = new Transform[3];

        Restaurants[0] = GameObject.Find("HannahsWayPoint").transform;
        Restaurants[1] = GameObject.Find("RamenWayPoint").transform;
        Restaurants[2] = GameObject.Find("SushiWayPoint").transform;

        Apartments = new Transform[4];

        Apartments[0] = GameObject.Find("ChipsWayPoint").transform;
        Apartments[1] = GameObject.Find("SeasandWayPoint").transform;
        Apartments[2] = GameObject.Find("28 Apartment Waypoint").transform;
        Apartments[3] = GameObject.Find("Halina WayPoint").transform;
    }


    void Update()
    {
        if (!orderSelected)
        {
            int Rselection = Random.Range(0, Restaurants.Length -1);
            int Aselection = Random.Range(0, Apartments.Length - 1);

            restaurantToGoTo = Restaurants[Rselection];
            apartmentToGoTo = Apartments[Aselection];
            orderSelected = true;

            orderScore = 100;

            Vector3 offset = new Vector3(0, -3, 0);
            target.transform.position = restaurantToGoTo.transform.position + offset;

        }

        if (orderSelected)
        {
            orderScore -= Time.deltaTime;
        }

        if (orderSelected && !orderPickedUp)
        {
            TravelToRestaurant();
        }

        if(orderPickedUp && orderSelected)
        {
            TravelToApartment();
        }

        if(orderScore<= 0)
        {
            // cancel the order if you have taken too long
            toGoBox.SetActive(false);
            StartCoroutine(Waiting());
        }

        Vector3 curMove = transform.position - previousPosition;
        curSpeed = curMove.magnitude / Time.deltaTime;
        previousPosition = transform.position;
    }

    void TravelToRestaurant() {
        agent.destination = target.transform.position;
        dist = Vector3.Distance(agent.transform.position, target.transform.position);
    }

    void TravelToApartment()
    {
        agent.destination = target.transform.position;
        dist = Vector3.Distance(agent.transform.position, target.transform.position);
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(Random.Range(3,5));
        orderPickedUp = false;
        orderSelected = false;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "AITarget")
        {
            if (curSpeed <= 1f)
            {
                if (!orderPickedUp)
                {
                    print("Order PickedUp");
                    target.transform.position = apartmentToGoTo.transform.position;
                    toGoBox.SetActive(true);
                    orderPickedUp = true;
                }

                if(orderPickedUp)
                {
                    print("Order Delivered");

                    if (enemy2)
                    {
                        GameManager.enemy2ScoreTotal += orderScore;
                        orderScore = 0;
                    }
                    else if (enemy3)
                    {
                        GameManager.enemy3ScoreTotal += orderScore;
                        orderScore = 0;
                    }
                    else if (enemy4)
                    {
                        GameManager.enemy4ScoreTotal += orderScore;
                        orderScore = 0;
                    }
                    enemyScore += orderScore;

                    toGoBox.SetActive(false);
                    StartCoroutine(Waiting());
                    Vector3 offset = new Vector3(0, -3, 0);
                }
            }
        }
    }
}
