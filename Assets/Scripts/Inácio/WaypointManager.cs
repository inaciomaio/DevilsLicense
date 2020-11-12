using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    public List<Vector3> waypoints = new List<Vector3>();

    private void Awake()
    {
        foreach (Transform waypoint in transform)
        {
            waypoints.Add(waypoint.position);
        }
    }
}