using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIGPS : MonoBehaviour
{
    Transform[] Restaurants;
    Transform[] Apartments;

    Transform apartmentToGoTo;
    Transform restaurantToGoTo;

    bool orderSelected;
    bool orderPickedUp;
    bool orderDelivered;

    public UnityEngine.AI.NavMeshAgent agent;
    float dist;

    public GameObject target;

    Rigidbody rb;
    Vector3 previousPosition;
    float curSpeed;

    public GameObject toGoBox;

    float orderScore;

    GraphPathfinding graphPathfinding;

    void Start()
    {

        graphPathfinding = FindObjectOfType<GraphPathfinding>();

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
            int Rselection = Random.Range(0, Restaurants.Length - 1);
            int Aselection = Random.Range(0, Apartments.Length - 1);

            restaurantToGoTo = Restaurants[Rselection];
            apartmentToGoTo = Apartments[Aselection];
            orderSelected = true;

            orderScore = 100;

            Vector3 offset = new Vector3(0, -3, 0);
            target.transform.position = restaurantToGoTo.transform.position + offset;
            TravelToRestaurant();
        }

        if (orderSelected)
        {
            orderScore -= Time.deltaTime;
        }

        //if(orderScore<= 0)
        //{ 
        // cancel the order
        // score = 0
        // bools are reset to false
        // waiting for 3-5 seconds
        // new order is selected
        //}

        Vector3 curMove = transform.position - previousPosition;
        curSpeed = curMove.magnitude / Time.deltaTime;
        previousPosition = transform.position;
    }

    void TravelToRestaurant()
    {
        Debug.Log("TravelToRestaurant");
        graphPathfinding.FindPath(graphPathfinding.FindNearestNode(restaurantToGoTo.transform), graphPathfinding.FindNearestNode(this.gameObject.transform));
        Debug.Log(graphPathfinding.FindNearestNode(target.transform));
        Debug.Log(graphPathfinding.FindNearestNode(this.gameObject.transform));
        float step = .000010f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(target.transform.position, this.gameObject.transform.position, step);
        //agent.destination = target.transform.position;
        //dist = Vector3.Distance(agent.transform.position, target.transform.position);
    }

    void TravelToApartment()
    {
        agent.destination = target.transform.position;
        dist = Vector3.Distance(agent.transform.position, target.transform.position);
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(Random.Range(3, 5));
        orderPickedUp = false;
        orderSelected = false;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "AITarget")
        {
            if (curSpeed <= .01f)
            {
                if (!orderPickedUp)
                {
                    print("Order PickedUp");
                    toGoBox.SetActive(true);
                    Vector3 offset = new Vector3(0, -3, 0);
                    target.transform.position = apartmentToGoTo.transform.position + offset;
                    TravelToApartment();
                    orderPickedUp = true;
                }

                else
                {
                    print("Order Delivered");
                    //AddScoreToGameManagerTotal
                    //OrderScore = 0;
                    toGoBox.SetActive(false);
                    StartCoroutine(Waiting());
                    Vector3 offset = new Vector3(0, -3, 0);
                }
            }
        }
    }
}