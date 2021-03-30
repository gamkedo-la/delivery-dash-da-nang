using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulloutTriggerScript : MonoBehaviour
{
    public GameObject parentScooter;
    private BoxCollider boxCollider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            parentScooter.transform.transform.Rotate(0, 180, 0);
            parentScooter.transform.GetComponent<NPCScooterFlatScreenDrive>().enabled = true;
        }
    }

    void OnDrawGizmos()
    {
        boxCollider = transform.GetComponent<BoxCollider>();
        // Draw a semitransparent blue cube at the transforms position
        Gizmos.color = new Color(1, 0, 0, 1f);
        Gizmos.DrawCube(new Vector3(boxCollider.center.x, boxCollider.center.y, boxCollider.center.z), new Vector3(boxCollider.size.x, boxCollider.size.y, boxCollider.size.y));
    }
}
