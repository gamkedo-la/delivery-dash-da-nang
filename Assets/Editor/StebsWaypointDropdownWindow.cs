using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class StebsWaypointDropdownWindow : EditorWindow
{
    [MenuItem("Tools/Stebs Waypoint Editor")]
    public static void Open()
    {
        GetWindow<StebsWaypointDropdownWindow>();
    }

    public Transform parentObjectWaypointHolder;

    private void OnGUI()
    {
        SerializedObject obj = new SerializedObject(this);

        EditorGUILayout.PropertyField(obj.FindProperty("parentObjectWaypointHolder"));

        if (parentObjectWaypointHolder == null)
        {
            EditorGUILayout.HelpBox("Waypoint Holder transform must be selected. Please assign a Waypoint Holder transform.", MessageType.Warning);
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
        GameObject stebsWaypoint = new GameObject("StebsWaypoint " + parentObjectWaypointHolder.childCount, typeof(StebsWaypoint2));
        stebsWaypoint.transform.SetParent(parentObjectWaypointHolder, false);

        StebsWaypoint2 waypoint = stebsWaypoint.GetComponent<StebsWaypoint2>();
        if (parentObjectWaypointHolder.childCount > 1)
        {
            waypoint.stebsPreviousWaypoint = parentObjectWaypointHolder.GetChild(parentObjectWaypointHolder.childCount - 2).GetComponent<StebsWaypoint2>();
            waypoint.stebsPreviousWaypoint.stebsNextWaypoint = waypoint;
            //place the waypoint at the last position
            waypoint.transform.position = waypoint.stebsPreviousWaypoint.transform.position;
            waypoint.transform.forward = waypoint.stebsPreviousWaypoint.transform.forward;
        }

        Selection.activeGameObject = stebsWaypoint.gameObject;
    }

    void CreateWayPointBefore()
    {
        GameObject stebsWaypoint = new GameObject("Waypoint " + parentObjectWaypointHolder.childCount, typeof(StebsWaypoint2));
        stebsWaypoint.transform.SetParent(parentObjectWaypointHolder, false);

        StebsWaypoint2 newWaypoint = stebsWaypoint.GetComponent<StebsWaypoint2>();

        StebsWaypoint2 selectedWaypoint = Selection.activeGameObject.GetComponent<StebsWaypoint2>();

        stebsWaypoint.transform.position = selectedWaypoint.transform.position;
        stebsWaypoint.transform.forward = selectedWaypoint.transform.forward;

        if (selectedWaypoint.stebsPreviousWaypoint != null)
        {
            newWaypoint.stebsPreviousWaypoint = selectedWaypoint.stebsPreviousWaypoint;
            selectedWaypoint.stebsPreviousWaypoint.stebsNextWaypoint = newWaypoint;
        }

        newWaypoint.stebsNextWaypoint = selectedWaypoint;

        selectedWaypoint.stebsPreviousWaypoint = newWaypoint;

        newWaypoint.transform.SetSiblingIndex(selectedWaypoint.transform.GetSiblingIndex());

    }

    void CreateWayPointAfter()
    {
        GameObject stebsWaypoint = new GameObject("Waypoint " + parentObjectWaypointHolder.childCount, typeof(StebsWaypoint2));
        stebsWaypoint.transform.SetParent(parentObjectWaypointHolder, false);

        StebsWaypoint2 newWaypoint = stebsWaypoint.GetComponent<StebsWaypoint2>();

        StebsWaypoint2 selectedWaypoint = Selection.activeGameObject.GetComponent<StebsWaypoint2>();

        stebsWaypoint.transform.position = selectedWaypoint.transform.position;
        stebsWaypoint.transform.forward = selectedWaypoint.transform.forward;

        newWaypoint.stebsPreviousWaypoint = selectedWaypoint;

        if (selectedWaypoint.stebsNextWaypoint != null)
        {
            selectedWaypoint.stebsNextWaypoint.stebsPreviousWaypoint = newWaypoint;
            newWaypoint.stebsNextWaypoint = selectedWaypoint.stebsNextWaypoint;
        }

        selectedWaypoint.stebsNextWaypoint = newWaypoint;

        newWaypoint.transform.SetSiblingIndex(selectedWaypoint.transform.GetSiblingIndex());

        Selection.activeGameObject = newWaypoint.gameObject;
    }

    void RemoveWayPoint()
    {
        StebsWaypoint2 selectedWaypoint = Selection.activeGameObject.GetComponent<StebsWaypoint2>();

        if (selectedWaypoint.stebsNextWaypoint != null)
        {
            selectedWaypoint.stebsNextWaypoint.stebsPreviousWaypoint = selectedWaypoint.stebsPreviousWaypoint;
        }

        if (selectedWaypoint.stebsPreviousWaypoint != null)
        {
            selectedWaypoint.stebsPreviousWaypoint.stebsNextWaypoint = selectedWaypoint.stebsNextWaypoint;
            Selection.activeGameObject = selectedWaypoint.stebsPreviousWaypoint.gameObject;
        }

        DestroyImmediate(selectedWaypoint.gameObject);
    }
    
}
