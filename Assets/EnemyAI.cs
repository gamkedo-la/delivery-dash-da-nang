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

    public NavMeshAgent agent;
    float dist;

    void Start() {

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
            int Rselection = Random.Range(0, Restaurants.Length);
            int Aselection = Random.Range(0, Apartments.Length);

            restaurantToGoTo = Restaurants[Rselection];
            apartmentToGoTo = Apartments[Aselection];
            orderSelected = true;

            TravelToRestaurant();
        }
    }

    void TravelToRestaurant() {
        agent.destination = restaurantToGoTo.transform.position;
        dist = agent.remainingDistance;
        if (dist <= 2)
        {
            print("Order PickedUp");
            TravelToApartment();
        }
    }

    void TravelToApartment()
    {
        agent.destination = apartmentToGoTo.transform.position;
        dist = agent.remainingDistance;
        if (dist <= 2)
        {
            print("Order Completed");
            Waiting();
        }
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(Random.Range(0,5));
        orderSelected = false;
    }
}
