using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarAI : MonoBehaviour
{
    private NavMeshAgent agent;

    public Vector3 targetDestination;

    private WaypointManager waypoint;

    private void Awake()
    {
        waypoint = FindObjectOfType<WaypointManager>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        targetDestination = waypoint.waypoints[Random.Range(0, waypoint.waypoints.Count - 1)];
        agent.destination = targetDestination;
    }

    private void Rotate()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }
}