using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[DrawGizmo(GizmoType.NonSelected | GizmoType.Selected | GizmoType.Pickable)]
public class StebsWaypoint2 : MonoBehaviour
{

    
        public StebsWaypoint2 stebsPreviousWaypoint;
        public StebsWaypoint2 stebsNextWaypoint;

        [Range(0f, 40f)]
        public float width = 9f;
        public List<StebsWaypoint2> branches;

        [Range(0f, 1f)]
        public float branchRatio = 0.5f;

        public Vector3 GetPosition()
        {
            Vector3 minBound = transform.position + transform.right; /* width / 2f;*/
            Vector3 maxBound = transform.position - transform.right; /* width / 2f;*/

            return Vector3.Lerp(minBound, maxBound, Random.Range(0f, 1f));
        }

    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow * 0.5f;
        Gizmos.DrawSphere(transform.position, 2);

        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position + (transform.right * width / 2f),
                transform.position - (transform.right * width / 2));

        if (stebsPreviousWaypoint != null)
        {
            Gizmos.color = Color.blue;


            Gizmos.DrawLine(transform.position, stebsPreviousWaypoint.transform.position);
        }

        if (stebsNextWaypoint != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, stebsNextWaypoint.transform.position);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 2);
    }
    //public static void OnDrawSceneGizmo(StebsWaypoint2 waypoint, GizmoType gizmoType)
    //{
    //Debug.Log("anything");
    //if ((gizmoType & GizmoType.Selected) != 0)
    //{
    //    Gizmos.color = Color.yellow;
    //}
    //else
    //{
    //    Gizmos.color = Color.yellow * .5f;
    //}

    //Gizmos.DrawSphere(waypoint.transform.position, 2f);
}
