using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Waypoint PreviousWaypoint;

    public List<Waypoint> NextWaypoints = new List<Waypoint>();

    private void Start()
    {
        for(int i = NextWaypoints.Count - 1; i > -1; --i)
        {
            var f = NextWaypoints[i];
            if(f == null)
            {
                NextWaypoints.Remove(f);
            }
        }

    }

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