using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public float TargetSpeed;

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

        if(TargetSpeed == 0)
        {
            TargetSpeed = 8.333333333f;
        }

    }

    public Vector2 GetPosition()
    {
        return transform.position;
    }
}