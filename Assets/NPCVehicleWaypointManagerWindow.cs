using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NPCVehicleWaypointManagerWindow : EditorWindow
{
    [MenuItem("Tools/NPC Vehicle Waypoint Editor")]
    public static void Open()
    {
        GetWindow<NPCVehicleWaypointManagerWindow>();
    }

    public Transform VehicleSpawnerWithWaypointChildren;

    private void OnGUI()
    {
        SerializedObject obj = new SerializedObject(this);

        EditorGUILayout.PropertyField(obj.FindProperty("VehicleSpawnerWithWaypointChildren"));
        Debug.Log("hello OnGUI");
        //if (VehicleSpawnerWithWaypointChildren == null)
        //{
            //EditorGUILayout.HelpBox("Root transform must be selected. Please assign a root transform.", MessageType.Warning);
        //}    
        //else
        //{
            EditorGUILayout.BeginVertical("box");
            DrawButtons();
            EditorGUILayout.EndVertical();

        //}    
        obj.ApplyModifiedProperties();
    }

    void DrawButtons()
    {
        if (GUILayout.Button("Create Waypoint"))
        {
            CreateWaypoint();
        }

        if (Selection.activeObject != null && Selection.activeGameObject.GetComponent<NPCVehicleWaypoint>())
        {
            if (GUILayout.Button("Add Branch Waypoint"))
            {
                CreateWaypointBranch();
            }

            if (GUILayout.Button("Create Waypoint Before"))
            {
                CreateWaypointBefore();
            }
            if (GUILayout.Button("Create Waypoint After"))
            {
                CreateWaypointAfter();
            }
            if (GUILayout.Button("Remove WayPoint"))
            {
                RemoveWaypoint();
            }
        }
    }

    void CreateWaypointBranch()
    {
        
    }    

    void CreateWaypointBefore()
    {
        GameObject NPCVehicleWaypointObject = new GameObject("NPC Vehicle Waypoint" + VehicleSpawnerWithWaypointChildren.childCount, typeof(NPCVehicleWaypoint));
        NPCVehicleWaypointObject.transform.SetParent(VehicleSpawnerWithWaypointChildren, false);

        NPCVehicleWaypoint newVehicleWaypoint = NPCVehicleWaypointObject.GetComponent<NPCVehicleWaypoint>();

        NPCVehicleWaypoint selectedVehicleWaypoint = Selection.activeGameObject.GetComponent<NPCVehicleWaypoint>();

        NPCVehicleWaypointObject.transform.position = selectedVehicleWaypoint.transform.position;
        NPCVehicleWaypointObject.transform.forward = selectedVehicleWaypoint.transform.forward;

        if (selectedVehicleWaypoint.previousWaypoint != null)
        {
            newVehicleWaypoint.previousWaypoint = selectedVehicleWaypoint.previousWaypoint;
            selectedVehicleWaypoint.previousWaypoint.nextWaypoint = newVehicleWaypoint;
        }

        newVehicleWaypoint.nextWaypoint = selectedVehicleWaypoint;

        selectedVehicleWaypoint.previousWaypoint = newVehicleWaypoint;

        newVehicleWaypoint.transform.SetSiblingIndex(selectedVehicleWaypoint.transform.GetSiblingIndex());

        Selection.activeGameObject = newVehicleWaypoint.gameObject;
    }    

    void CreateWaypointAfter()
    {
        GameObject NPCVehicleWaypointObject = new GameObject("NPC Vehicle Waypoint" + VehicleSpawnerWithWaypointChildren.childCount, typeof(NPCVehicleWaypoint));
        NPCVehicleWaypointObject.transform.SetParent(VehicleSpawnerWithWaypointChildren, false);

        NPCVehicleWaypoint newVehicleWaypoint = NPCVehicleWaypointObject.GetComponent<NPCVehicleWaypoint>();

        NPCVehicleWaypoint selectedVehicleWaypoint = Selection.activeGameObject.GetComponent<NPCVehicleWaypoint>();

        NPCVehicleWaypointObject.transform.position = selectedVehicleWaypoint.transform.position;
        NPCVehicleWaypointObject.transform.forward = selectedVehicleWaypoint.transform.forward;

        if (selectedVehicleWaypoint.nextWaypoint != null)
        {
            selectedVehicleWaypoint.nextWaypoint.previousWaypoint = newVehicleWaypoint;
            newVehicleWaypoint.nextWaypoint = selectedVehicleWaypoint.nextWaypoint;
        }

        selectedVehicleWaypoint.nextWaypoint = newVehicleWaypoint;

        newVehicleWaypoint.transform.SetSiblingIndex(selectedVehicleWaypoint.transform.GetSiblingIndex());

        Selection.activeGameObject = newVehicleWaypoint.gameObject;
    }    

    void RemoveWaypoint()
    {
        NPCVehicleWaypoint selectedVehicleWaypoint = Selection.activeGameObject.GetComponent<NPCVehicleWaypoint>();

        if (selectedVehicleWaypoint.nextWaypoint != null)
        {
            selectedVehicleWaypoint.nextWaypoint.previousWaypoint = selectedVehicleWaypoint.previousWaypoint;
        }    
        if (selectedVehicleWaypoint.previousWaypoint != null)
        {
            selectedVehicleWaypoint.previousWaypoint.nextWaypoint = selectedVehicleWaypoint.nextWaypoint;
            Selection.activeGameObject = selectedVehicleWaypoint.previousWaypoint.gameObject;
        }

        DestroyImmediate(selectedVehicleWaypoint.gameObject);
    }    

    void CreateWaypoint()
    {
        GameObject NPCVehicleWaypointObject = new GameObject("NPC Vehicle Waypoint" + VehicleSpawnerWithWaypointChildren.childCount, typeof(NPCVehicleWaypoint));
        NPCVehicleWaypointObject.transform.SetParent(VehicleSpawnerWithWaypointChildren, false);

        NPCVehicleWaypoint NPCVehicleWaypoint = NPCVehicleWaypointObject.GetComponent<NPCVehicleWaypoint>();
        if (VehicleSpawnerWithWaypointChildren.childCount > 1)
        {
            NPCVehicleWaypoint.previousWaypoint = VehicleSpawnerWithWaypointChildren.GetChild(VehicleSpawnerWithWaypointChildren.childCount - 2).GetComponent<NPCVehicleWaypoint>();
            NPCVehicleWaypoint.previousWaypoint.nextWaypoint = NPCVehicleWaypoint;

            NPCVehicleWaypoint.transform.position = NPCVehicleWaypoint.previousWaypoint.transform.position;
            NPCVehicleWaypoint.transform.forward = NPCVehicleWaypoint.previousWaypoint.transform.forward;

            Selection.activeGameObject = NPCVehicleWaypoint.gameObject;
        }    
    }    
}
