using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign_TurnLeft : MonoBehaviour
{
    private CarAI car;
    public Waypoint currentWaypoint;
    public bool CanNPCsUse = true;

    private void Awake()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CanNPCsUse)
        {
            if (collision.CompareTag("Car") | collision.CompareTag("Player"))
            {
                car = collision.GetComponent<CarAI>();
                car.SetDestination(currentWaypoint.GetPosition());
            }
            
        }
        else if (collision.CompareTag("Player"))
        {
            car = collision.GetComponent<CarAI>();
            car.SetDestination(currentWaypoint.GetPosition());
        }
    }
}
