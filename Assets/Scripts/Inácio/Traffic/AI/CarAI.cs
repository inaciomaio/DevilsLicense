using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAI : MonoBehaviour
{
    public float Speed = 2f;

    public float TurningSpeed = 2f;

    private Vector2 destination;

    public bool HasReachedDestination;

    private Rigidbody2D car;

    private void Awake()
    {
        car = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        AimToWaypoint();
        MinDstToWaypoint();
        //CheckWallDistance();
        Drive();
    }

    private void AimToWaypoint()
    {
        Vector3 target = new Vector3(destination.x, destination.y);
        Vector3 destinationVector = target - transform.position;
        float angle = Mathf.Atan2(-destinationVector.x, destinationVector.y) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * TurningSpeed);
    }

    private void MinDstToWaypoint()
    {
        if (Vector2.Distance(transform.position, destination) < .5f)
        {
            HasReachedDestination = true;
        }
    }

    private void Drive()
    {
        float Distance = Vector2.Distance(transform.position, destination);

        transform.position += transform.up * Time.deltaTime * Vector2.Distance(transform.position, destination);
        // car.AddForce(transform.up * Speed);
        // car.drag = 4 / Vector2.Distance(transform.position, destination);
    }

    // private void CheckWallDistance()
    // {
    //     RaycastHit2D right = Physics2D.Raycast(transform.position, transform.position * .5f);
    //
    //     if (right.collider)
    //     {
    //         Debug.Log(right.distance + right.collider.name);
    //     }
    // }

    public void SetDestination(Vector2 destination)
    {
        this.destination = destination;
        HasReachedDestination = false;
    }
}