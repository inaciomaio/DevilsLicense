using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

[InitializeOnLoad()]
public class PathEditor
{
    [DrawGizmo(GizmoType.NonSelected | GizmoType.Selected | GizmoType.Pickable)]
    public static void OnDrawSceneGizmo(Waypoint waypoint, GizmoType gizmoType)
    {
        if ((gizmoType & GizmoType.Selected) != 0)
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.red;
        }

        Gizmos.DrawSphere(waypoint.transform.position, .20f);


        foreach (Waypoint Waypoint in waypoint.NextWaypoints)
        {
            if (Waypoint != null)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawLine(waypoint.transform.position, Waypoint.transform.position);
            }
        }
    }
}

#endif