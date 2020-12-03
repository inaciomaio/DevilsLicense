using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointNavigator : MonoBehaviour
{
    private CarAI car;
    public Waypoint currentWaypoint;

    private void Awake()
    {
        car = GetComponent<CarAI>();
    }

    private void Start()
    {
        car.SetDestination(currentWaypoint.GetPosition());
    }

    private void Update()
    {
        if (car.HasReachedDestination)
        {
            int direction = Random.Range(0, currentWaypoint.NextWaypoints.Count);
            Debug.Log(direction);
            currentWaypoint = currentWaypoint.NextWaypoints[direction];
            car.SetDestination(currentWaypoint.GetPosition());
        }
    }
}