using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPSCameraFollow : MonoBehaviour
{
    public Transform player;

    [SerializeField]
    private float cameraXRotation = 90f;
    private void LateUpdate()
    {
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        transform.rotation = Quaternion.Euler(cameraXRotation, player.eulerAngles.y, 0f);
    }
}
