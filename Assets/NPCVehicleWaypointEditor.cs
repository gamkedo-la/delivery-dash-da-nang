using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad()]
public class NPCVehicleWaypointEditor
{
    [DrawGizmo(GizmoType.NonSelected | GizmoType.Selected | GizmoType.Pickable)]
    public static void OnDrawSceneGizmo(NPCVehicleWaypoint npcVehicleWaypoint, GizmoType gizmoType)
    {
        if((gizmoType & GizmoType.Selected) != 0)
        {
            Gizmos.color = Color.black;
        }
        else
        {
            Gizmos.color = Color.black * 0.5f;
        }

        Gizmos.DrawSphere(npcVehicleWaypoint.transform.position, 2f);

        Gizmos.color = Color.white;
        Gizmos.DrawLine(npcVehicleWaypoint.transform.position + (npcVehicleWaypoint.transform.right * npcVehicleWaypoint.width / 2f ),
            npcVehicleWaypoint.transform.position - (npcVehicleWaypoint.transform.right * npcVehicleWaypoint.width / 2f ) );

        //Debug.Log(npcVehicleWaypoint.transform.position + (npcVehicleWaypoint.transform.right * npcVehicleWaypoint.width / 2f));
        //Debug.Log(npcVehicleWaypoint.transform.position - npcVehicleWaypoint.transform.right - (npcVehicleWaypoint.transform.position * npcVehicleWaypoint.width / 2f));
        //Debug.Log("npcVehicleWaypoint.transform.position: " + npcVehicleWaypoint.transform.position);
        //Debug.Log("npcVehicleWaypoint.transform.right: " + npcVehicleWaypoint.transform.right);

        //Gizmos.DrawLine(waypoint.transform.position + (waypoint.transform.right * waypoint.width / 2f),
        //        waypoint.transform.position - (waypoint.transform.right * waypoint.width / 2));

        if (npcVehicleWaypoint.previousWaypoint != null)
        {
            //Debug.Log("npcVehicleWaypoint Width" + npcV)
            Gizmos.color = Color.cyan;
            Vector3 offset = npcVehicleWaypoint.transform.right * npcVehicleWaypoint.width / 2f;
            Vector3 offsetTo = npcVehicleWaypoint.previousWaypoint.transform.right * npcVehicleWaypoint.previousWaypoint.width / 2f;

            Gizmos.DrawLine(npcVehicleWaypoint.transform.position + offset, npcVehicleWaypoint.previousWaypoint.transform.position + offsetTo);
        }

        if (npcVehicleWaypoint.nextWaypoint != null)
        {
            Gizmos.color = Color.gray;
            Vector3 offset = npcVehicleWaypoint.transform.right * -npcVehicleWaypoint.width / 2f;
            Vector3 offsetTo = npcVehicleWaypoint.nextWaypoint.transform.right * -npcVehicleWaypoint.nextWaypoint.width / 2f;

            Gizmos.DrawLine(npcVehicleWaypoint.transform.position + offset, npcVehicleWaypoint.nextWaypoint.transform.position + offsetTo);
        }

    }
}
