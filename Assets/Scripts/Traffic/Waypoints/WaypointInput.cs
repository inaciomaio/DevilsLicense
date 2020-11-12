using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointInput : MonoBehaviour
{
    public CarAI Controller;

    public Waypoint CurrentWaypoint;

    private void Awake()
    {
        Controller = GetComponent<CarAI>();
    }

    private void Start()
    {
        Controller.SetDestination(CurrentWaypoint.transform.position);
    }

    private void Update()
    {
        if (Controller.HasReachedDestination)
        {
            CurrentWaypoint = CurrentWaypoint.NextWaypoint;
            Controller.SetDestination(CurrentWaypoint.transform.position);
        }
    }
}