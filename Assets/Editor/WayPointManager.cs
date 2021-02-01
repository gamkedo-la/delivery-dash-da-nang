using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WayPointManager : EditorWindow
{
    [MenuItem("Tools/Waypoint Editor")]
    public static void Open()
    {
        GetWindow<WayPointManager>();
    }

    public Transform wayPointRoot;

    private void OnGUI()
    {
        SerializedObject obj = new SerializedObject(this);

        EditorGUILayout.PropertyField(obj.FindProperty("wayPointRoot"));

        if (wayPointRoot == null)
        {
            EditorGUILayout.HelpBox("Root transform must be selected. Please assign a root transform.", MessageType.Warning);
        }

        else
        {
            EditorGUILayout.BeginVertical("box");
            DrawButtons();
            EditorGUILayout.EndVertical();
        }

        obj.ApplyModifiedProperties();
    }

    void DrawButtons()
    {
        if (GUILayout.Button("Create Waypoint"))
        {
            CreateWayPoint();
        }

        if (Selection.activeObject != null && Selection.activeGameObject.GetComponent<Waypoint>())
        {
            if (GUILayout.Button("Add Branch Waypoint"))
            {
                CreateBranch();
            }

            if (GUILayout.Button("Create Waypoint Before"))
            {
                CreateWayPointBefore();
            }
            if (GUILayout.Button("Create Waypoint After"))
            {
                CreateWayPointAfter();
            }
            if (GUILayout.Button("Remove WayPoint"))
            {
                RemoveWayPoint();
            }
        }
    }

    void CreateWayPoint()
    {
        GameObject wayPointObject = new GameObject("Waypoint " + wayPointRoot.childCount, typeof(Waypoint));
        wayPointObject.transform.SetParent(wayPointRoot, false);

        Waypoint waypoint = wayPointObject.GetComponent<Waypoint>();
        if (wayPointRoot.childCount > 1)
        {
            waypoint.previousWayPoint = wayPointRoot.GetChild(wayPointRoot.childCount - 2).GetComponent<Waypoint>();
            waypoint.previousWayPoint.nextWayPoint = waypoint;
            //place the waypoint at the last position
            waypoint.transform.position = waypoint.previousWayPoint.transform.position;
            waypoint.transform.forward = waypoint.previousWayPoint.transform.forward;
        }

        Selection.activeGameObject = waypoint.gameObject;
    }

    void CreateWayPointBefore()
    {
        GameObject waypointObject = new GameObject("Waypoint " + wayPointRoot.childCount, typeof(Waypoint));
        waypointObject.transform.SetParent(wayPointRoot, false);

        Waypoint newWaypoint = waypointObject.GetComponent<Waypoint>();

        Waypoint selectedWaypoint = Selection.activeGameObject.GetComponent<Waypoint>();

        waypointObject.transform.position = selectedWaypoint.transform.position;
        waypointObject.transform.forward = selectedWaypoint.transform.forward;

        if (selectedWaypoint.previousWayPoint != null)
        {
            newWaypoint.previousWayPoint = selectedWaypoint.previousWayPoint;
            selectedWaypoint.previousWayPoint.nextWayPoint = newWaypoint;
        }

        newWaypoint.nextWayPoint = selectedWaypoint;

        selectedWaypoint.previousWayPoint = newWaypoint;

        newWaypoint.transform.SetSiblingIndex(selectedWaypoint.transform.GetSiblingIndex());

    }

    void CreateWayPointAfter()
    {
        GameObject waypointObject = new GameObject("Waypoint " + wayPointRoot.childCount, typeof(Waypoint));
        waypointObject.transform.SetParent(wayPointRoot, false);

        Waypoint newWaypoint = waypointObject.GetComponent<Waypoint>();

        Waypoint selectedWaypoint = Selection.activeGameObject.GetComponent<Waypoint>();

        waypointObject.transform.position = selectedWaypoint.transform.position;
        waypointObject.transform.forward = selectedWaypoint.transform.forward;

        newWaypoint.previousWayPoint = selectedWaypoint;

        if (selectedWaypoint.nextWayPoint != null)
        {
            selectedWaypoint.nextWayPoint.previousWayPoint = newWaypoint;
            newWaypoint.nextWayPoint = selectedWaypoint.nextWayPoint;
        }

        selectedWaypoint.nextWayPoint = newWaypoint;

        newWaypoint.transform.SetSiblingIndex(selectedWaypoint.transform.GetSiblingIndex());

        Selection.activeGameObject = newWaypoint.gameObject;
    }

    void RemoveWayPoint()
    {
        Waypoint selectedWaypoint = Selection.activeGameObject.GetComponent<Waypoint>();

        if (selectedWaypoint.nextWayPoint != null)
        {
            selectedWaypoint.nextWayPoint.previousWayPoint = selectedWaypoint.previousWayPoint;
        }

        if (selectedWaypoint.previousWayPoint != null)
        {
            selectedWaypoint.previousWayPoint.nextWayPoint = selectedWaypoint.nextWayPoint;
            Selection.activeGameObject = selectedWaypoint.previousWayPoint.gameObject;
        }

        DestroyImmediate(selectedWaypoint.gameObject);
    }

    void CreateBranch()
    {
        GameObject waypointObject = new GameObject("Waypoint " + wayPointRoot.childCount, typeof(Waypoint));
        waypointObject.transform.SetParent(wayPointRoot, false);

        Waypoint waypoint = waypointObject.GetComponent<Waypoint>();

        Waypoint branchedFrom = Selection.activeGameObject.GetComponent<Waypoint>();
        branchedFrom.branches.Add(waypoint);

        waypoint.transform.position = branchedFrom.transform.position;
        waypoint.transform.forward = branchedFrom.transform.forward;

        Selection.activeGameObject = waypoint.gameObject;
    }
}
