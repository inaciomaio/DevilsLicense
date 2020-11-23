using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad()]
public class PathEditor
{
    [DrawGizmo(GizmoType.NonSelected | GizmoType.Selected | GizmoType.Pickable)]
    public static void OnDrawSceneGizmo(Waypoint waypoint, GizmoType gizmoType)
    {
        if ((gizmoType & GizmoType.Selected) != 0)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.red * .5f;
        }

        Gizmos.DrawSphere(waypoint.transform.position, .20f);

        if (waypoint.NextWaypoint != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(waypoint.transform.position, waypoint.NextWaypoint.transform.position);
        }
    }
}