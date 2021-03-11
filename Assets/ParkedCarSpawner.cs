using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkedCarSpawner : MonoBehaviour
{
    public int minCarCount = 2;
    public int maxCarCount = 6;
    public float chancePerCar = 0.5f;
    public float carSpacing = 25f;
    public List<GameObject> prefabs;

    void Start()
    {
        int count = Random.Range(minCarCount,maxCarCount);
        Debug.Log("Spawning "+count+" parked cars!");
        
        float dist = 0f;
        
        for (int num=0; num<count; num++) {
            
            if (Random.value < chancePerCar) {
                int picked = Random.Range(0,prefabs.Count);
                Debug.Log("Spawning parked car " + picked + " at dist " + dist);
                GameObject clone = Instantiate(prefabs[picked], new Vector3(0f,0f,0f), Quaternion.identity);
                clone.transform.SetParent(transform); // be a child of this object
                clone.transform.localPosition = new Vector3(0f,0f,dist+(carSpacing/2));
            } 
            // otherwise we leave a parking space

            dist += carSpacing; // grab bbox size and add padding

        }

    }
    void OnDrawGizmos()//Selected()
    {
        // Draw a semitransparent cube at the transforms position
        Gizmos.color = new Color(1, 0, 0, 0.25f);
        Vector3 cubePos = new Vector3(transform.position.x,transform.position.y,
            transform.position.z + maxCarCount * carSpacing / 2);
        Gizmos.DrawCube(cubePos, new Vector3(10, 10, maxCarCount * carSpacing));
    }
    
}
