using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offsetBehindBike;

    public Transform lookAtTarget;

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offsetBehindBike;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        this.gameObject.transform.LookAt(lookAtTarget);
    }

}
