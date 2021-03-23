using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[DrawGizmo(GizmoType.NonSelected | GizmoType.Selected | GizmoType.Pickable)]
public class StebsWaypointEditorScript : MonoBehaviour
{
    public static void OnDrawSceneGizmo(StebsWaypoint2 waypoint, GizmoType gizmoType)
    {
        
        if ((gizmoType & GizmoType.Selected) != 0)
        {
            Gizmos.color = Color.yellow;
        }
        else
        {
            Gizmos.color = Color.yellow * .5f;
        }

        Gizmos.DrawSphere(waypoint.transform.position, 2f);

        Gizmos.color = Color.white;
        Gizmos.DrawLine(waypoint.transform.position + (waypoint.transform.right * waypoint.width / 2f),
                waypoint.transform.position - (waypoint.transform.right * waypoint.width / 2));

        if (waypoint.stebsPreviousWaypoint != null)
        {
            Gizmos.color = Color.blue;
            

            Gizmos.DrawLine(waypoint.transform.position, waypoint.stebsPreviousWaypoint.transform.position);
        }

        if (waypoint.stebsNextWaypoint != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(waypoint.transform.position, waypoint.stebsNextWaypoint.transform.position);
        }
    }
    
}
