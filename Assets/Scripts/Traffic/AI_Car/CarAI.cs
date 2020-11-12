using System.Collections;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq.Expressions;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class CarAI : MonoBehaviour
{
    public float CarSpeed = 1;

    public float CarTurningSpeed = 1;

    public float DestinationOffset = 1;

    public bool HasReachedDestination;

    private Vector3 destination;

    private Rigidbody2D Car;

    private enum direction { right, left, forward }

    private void Awake()
    {
        Car = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Debug.DrawLine(transform.position, destination);
        DriveToDestination();
    }

    public void SetDestination(Vector3 Destination)
    {
        destination = Destination;
    }

    private void DriveToDestination()
    {
        float destinationDistance = Vector2.Distance(transform.position, destination);

        if (destinationDistance >= DestinationOffset)
        {
            HasReachedDestination = false;

            Vector3 dir = destination - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, dir);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, CarTurningSpeed);
            Car.AddRelativeForce(new Vector2(0, CarSpeed));
        }
        else
        {
            Debug.Log("Reached destination");
            HasReachedDestination = true;
        }
    }

    private void Stop()
    {
        CarSpeed = 0;
        Car.velocity = new Vector2(0, 0);
    }

    private void OnTriggerStay2D(Collider2D light)
    {
        Debug.Log(light.gameObject.GetComponent<TrafficLight>().Color);
        if (light.CompareTag("TrafficLight"))
        {
            Debug.Log(light.GetComponent<TrafficLight>().TimeUntilChange);
            if (light.GetComponent<TrafficLight>().Color == 0)
            {
                Stop();
            }
        }
    }
}