using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Waypoint NextWaypoint;
    public Waypoint PreviousWaypoint;
    public float Velocity;

    [Range(0.1f, 5f)]
    public float Width = 0.5f;
}