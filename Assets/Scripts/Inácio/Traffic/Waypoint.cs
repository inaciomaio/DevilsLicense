using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Waypoint PreviousWaypoint;

    public Waypoint NextWaypoint;

    public float GetDistance(int waypoint)
    {
        return Vector2.Distance(PreviousWaypoint.transform.position, NextWaypoint.transform.position);
    }

    public Vector2 GetPosition()
    {
        return transform.position;
    }
}