using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PathManager : EditorWindow
{
    [MenuItem("Tools/Waypoint Editor")]
    public static void Open()
    {
        GetWindow<PathManager>();
    }

    public Transform WaypointRoot;
    public GameObject CurrentlySelectedObject;

    public void OnGUI()
    {
        SerializedObject obj = new SerializedObject(this);

        EditorGUILayout.PropertyField(obj.FindProperty("WaypointRoot"));

        if (WaypointRoot == null)
        {
            EditorGUILayout.HelpBox("Root must be selected you fucking retard", MessageType.Warning);
        }
        else
        {
            EditorGUILayout.BeginVertical("box");
            DrawButtons();
            EditorGUILayout.EndVertical();
        }

        obj.ApplyModifiedProperties();
    }

    private void DrawButtons()
    {
        if (GUILayout.Button("Create Waypoint"))
        {
            CreateWaypoint();
        }
    }

    private void CreateWaypoint()
    {
        GameObject waypointObject = new GameObject("Waypoint " + WaypointRoot.childCount, typeof(Waypoint));
        waypointObject.transform.SetParent(WaypointRoot, false);

        Waypoint waypoint = waypointObject.GetComponent<Waypoint>();
        if (WaypointRoot.childCount > 1)
        {
            waypoint.PreviousWaypoint = WaypointRoot.GetChild(WaypointRoot.childCount - 2).GetComponent<Waypoint>();
            waypoint.PreviousWaypoint.NextWaypoints[waypoint.PreviousWaypoint.NextWaypoints.Count - 1] = waypoint;

            waypoint.transform.position = waypoint.PreviousWaypoint.transform.position;
            waypoint.transform.forward = waypoint.PreviousWaypoint.transform.forward;
        }

        Selection.activeGameObject = waypoint.gameObject;
    }
}