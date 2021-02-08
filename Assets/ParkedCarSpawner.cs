using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkedCarSpawner : MonoBehaviour
{
    public GameObject parkedCar1;

    public float parkedCarXSpread;
    public float parkedCarYSpread;
    public float parkedCarZSpread;

    void SpreadCars()
    {
        /*Vector3 RandomPosition = new Vector3(Random.Range(-parkedCarXSpread, parkedCarXSpread),
                                            (Random.Range(-parkedCarYSpread, parkedCarYSpread),
                                            (Random.Range(-parkedCarZSpread, parkedCarZSpread))

        GameObject clone = Instantiate(parkedCar1, RandomPosition, Quaternion.identity);*/
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
