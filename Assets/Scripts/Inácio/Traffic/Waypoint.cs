using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Waypoint PreviousWaypoint;

    public List<Waypoint> NextWaypoints = new List<Waypoint>();

    public float GetDistance()
    {
        foreach(Waypoint waypoint in PreviousWaypoint.NextWaypoints)
        {
            return Vector2.Distance(PreviousWaypoint.transform.position, waypoint.transform.position);
        }

        return 0;
        
    }

    public Vector2 GetPosition()
    {
        return transform.position;
    }
}