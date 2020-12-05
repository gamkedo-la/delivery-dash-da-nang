using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject[] target;
    public float[] smoothSpeed;

    public GameObject[] lookAtTarget;

    int viewWindowCount;

    private void LateUpdate()
    {
        Vector3 desiredPosition = target[viewWindowCount].transform.position;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed[viewWindowCount]);
        transform.position = smoothedPosition;

        this.gameObject.transform.LookAt(lookAtTarget[viewWindowCount].transform.position);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (viewWindowCount >= target.Length-1)
            {
                viewWindowCount = 0;
            }
            else
            {
                viewWindowCount++;
            }
        }
    }

}
