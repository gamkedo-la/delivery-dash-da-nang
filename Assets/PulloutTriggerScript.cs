using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulloutTriggerScript : MonoBehaviour
{
    public GameObject parentScooter;
    private BoxCollider thisBoxCollider;
    public GameObject otherParentTriggerObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            parentScooter.transform.transform.Rotate(0, 180, 0);
            parentScooter.transform.GetComponent<NPCScooterFlatScreenDrive>().enabled = true;
            otherParentTriggerObject.transform.GetComponent<BoxCollider>().isTrigger = false;
            gameObject.transform.GetComponent<BoxCollider>().isTrigger = false;
        }
    }

    void OnDrawGizmos()
    {
        thisBoxCollider = transform.GetComponent<BoxCollider>();
        // Draw a semitransparent blue cube at the transforms position
        Gizmos.color = new Color(1, 0, 0, 1f);
        Gizmos.DrawCube(new Vector3(gameObject.transform.GetComponent<BoxCollider>().center.x, gameObject.transform.GetComponent<BoxCollider>().center.y, gameObject.transform.GetComponent<BoxCollider>().center.z), 
            new Vector3(gameObject.transform.GetComponent<BoxCollider>().size.x, gameObject.transform.GetComponent<BoxCollider>().size.y, gameObject.transform.GetComponent<BoxCollider>().size.y));
    }
}
