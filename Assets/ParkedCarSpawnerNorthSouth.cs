using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkedCarSpawnerNorthSouth : MonoBehaviour
{
    public bool NorthSouth = true;
    public int minCarCount = 2;
    public int maxCarCount = 6;
    public float chancePerCar = 0.5f;
    public float carSpacing = 25f;
    public List<GameObject> prefabs;

    void Start()
    {
        int count = Random.Range(minCarCount,maxCarCount);
        //Debug.Log("Spawning "+count+" parked cars!");
        
        float dist = 0f;
        
        for (int num=0; num<count; num++) {
            
            if (Random.value < chancePerCar) {
                int picked = Random.Range(0,prefabs.Count);
                //Debug.Log("Spawning parked car " + picked + " at dist " + dist);
                
                GameObject clone = Instantiate(prefabs[picked], new Vector3(0f,0f,0f), Quaternion.identity);
                clone.transform.SetParent(transform); // be a child of this object
                if (NorthSouth) {
                    clone.transform.localPosition = new Vector3(0f,0f,dist+(carSpacing/2));
                } else { // East West
                    clone.transform.localPosition = new Vector3(dist+(carSpacing/2),0f,0f);
                    clone.transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
                }

            } 
            // otherwise we leave a parking space

            dist += carSpacing; // grab bbox size and add padding

        }

    }
    void OnDrawGizmos()//Selected()
    {
        Vector3 cubePos;
        Vector3 cubeSize;
        
        // Draw a semitransparent cube at the transforms position
        Gizmos.color = new Color(1, 0, 0, 0.25f);

        if (NorthSouth) {
            
            cubePos = new Vector3(
                transform.position.x,
                transform.position.y+2.5f,
                transform.position.z + maxCarCount * carSpacing / 2);
            
            cubeSize = new Vector3(10, 5, maxCarCount * carSpacing);

        } else { // East West

            cubePos = new Vector3(
                transform.position.x + maxCarCount * carSpacing / 2,
                transform.position.y+2.5f,
                transform.position.z);
            
            cubeSize = new Vector3(maxCarCount * carSpacing, 5, 10);

        }

        Gizmos.DrawCube(cubePos, cubeSize);
    }
    
}
