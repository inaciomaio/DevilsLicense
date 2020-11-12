/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointNavigator : MonoBehaviour
{
    public PedestrianController controller;

    public Waypoint currentWaypoint;

    private float direction;

    private void Awake()
    {
        controller = GetComponent<PedestrianController>();
    }

    private void Start()
    {
        Debug.Log(currentWaypoint.transform.position + " | " + currentWaypoint.GetPosition());
        direction = Mathf.RoundToInt(UnityEngine.Random.Range(0, 1));
        controller.SetDestination(currentWaypoint.transform.localPosition);
    }

    private void Update()
    {
        controller.SetDestination(currentWaypoint.transform.localPosition);

        if (controller.HasReachedDestination)
        {
            currentWaypoint = currentWaypoint.NextWaypoint;

            /* if (direction == 0)
             {
                 currentWaypoint = currentWaypoint.NextWaypoint;
             }
             else if (direction == 1)
             {
                 currentWaypoint = currentWaypoint.PreviousWaypoint;
             }
             controller.SetDestination(currentWaypoint.GetPosition());*/