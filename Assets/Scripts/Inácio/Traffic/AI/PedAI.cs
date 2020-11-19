using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PedAI : MonoBehaviour
{
    private NavMeshAgent agent;

    public Vector3 targetDestination;

    private WaypointManager waypoint;

    private void Awake()
    {
    }

    private void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        targetDestination = waypoint.waypoints[Random.Range(0, waypoint.waypoints.Count - 1)];
        agent.destination = targetDestination;
    }

    private void Update()
    {
    }
}