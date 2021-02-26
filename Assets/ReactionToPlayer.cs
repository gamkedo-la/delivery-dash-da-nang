using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactionToPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(Waiting());
        }
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(2f);
        GetComponent<BoxCollider>().enabled = true;
    }
}
