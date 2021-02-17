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

    public int enemyScore;

    void Start() {
        #region Testing Score
        if (enemy2)
        {
            GameManager.enemy2ScoreTotal = Random.Range(0, 100);
            enemyScore = GameManager.enemy2ScoreTotal;
        }
        if (enemy3)
        {
            GameManager.enemy3ScoreTotal = Random.Range(0, 100);
            enemyScore = GameManager.enemy3ScoreTotal;
        }

        if (enemy4)
        {
            GameManager.enemy4ScoreTotal = Random.Range(0, 100);
            enemyScore = GameManager.enemy4ScoreTotal;
        }
        #endregion
        rb = GetComponent<Rigidbody>();

        #region Setting locations
        Restaurants = new Transform[3];

        Restaurants[0] = GameObject.Find("HannahsWayPoint").transform;
        Restaurants[1] = GameObject.Find("RamenWayPoint").transform;
        Restaurants[2] = GameObject.Find("SushiWayPoint").transform;

        Apartments = new Transform[4];

        Apartments[0] = GameObject.Find("ChipsWayPoint").transform;
        Apartments[1] = GameObject.Find("SeasandWayPoint").transform;
        //Apartments[2] = GameObject.Find("28 Apartment Waypoint").transform;
        Apartments[3] = GameObject.Find("Halina WayPoint").transform;
        // FIXME: some of the above objects do not exist

        #endregion
        ChooseAnOrder();
    }

    void ChooseAnOrder()
    {
        orderPickedUp = false;
        orderSelected = false;
        toGoBox.SetActive(false);

        int Rselection = Random.Range(0, Restaurants.Length);
        int Aselection = Random.Range(0, Apartments.Length);

        restaurantToGoTo = Restaurants[Rselection];
        apartmentToGoTo = Apartments[Aselection];

        orderScore = 100; 
        orderSelected = true;

        target.transform.position = restaurantToGoTo.transform.position;
    }


    void Update()
    {
        if (orderSelected)
        {
            orderScore -= Time.deltaTime;
        }

        if (orderSelected)
        {
            if (!orderPickedUp)
            {
                TravelToRestaurant();
            }
            if (orderPickedUp)
            {
                TravelToApartment();
            }
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
        yield return new WaitForSeconds(3);
        curSpeed = 0;
        target.GetComponent<BoxCollider>().enabled = true;
        ChooseAnOrder();
    }

    IEnumerator Waiting2()
    {
        yield return new WaitForSeconds(1);
        curSpeed = 0;
        toGoBox.SetActive(true);
        orderPickedUp = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "AITarget")
        {
            if (orderPickedUp)
            {
                target.GetComponent<BoxCollider>().enabled = false; 
                print("Order Delivered");

                if (enemy2)
                {
                    GameManager.enemy2ScoreTotal += (int)orderScore;
                    orderScore = 0;
                }
                else if (enemy3)
                {
                    GameManager.enemy3ScoreTotal += (int) orderScore;
                    orderScore = 0;
                }
                else if (enemy4)
                {
                    GameManager.enemy4ScoreTotal += (int)orderScore;
                    orderScore = 0;
                }
                StartCoroutine(Waiting());
            }
        }
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
                    StartCoroutine(Waiting2());
                }                
            }
        }
    }
}
