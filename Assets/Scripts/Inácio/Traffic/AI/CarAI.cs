using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAI : MonoBehaviour
{
    private float currentVelocity;

    [Range(30, 50)]
    public int MaxVelocity = 30;

    [Range(0, 5)]
    public float EnginePower = 2f;

    public float TurningSpeed = 2f;

    private Vector2 destination;

    private Vector3 previousPosition;

    public bool HasReachedDestination;

    private Rigidbody2D car;

    private float steerAngle;

    private float wheelDistance = 20;

    public bool CanDrive = true;

    private void Awake()
    {
        Vector3 previousPosition = transform.position;
        car = GetComponent<Rigidbody2D>();
        Physics2D.queriesStartInColliders = false;
    }

    private void Update()
    {
        //MeasureVelocity();
        AimToWaypoint();
        MinDstToWaypoint();
        Raycast();
        //CheckWallDistance();
        Drive();
    }

     private void AimToWaypoint()
     {
         Vector3 target = new Vector3(destination.x, destination.y);
         Vector3 destinationVector = target - transform.position;
         steerAngle = Mathf.Atan2(-destinationVector.x, destinationVector.y) * Mathf.Rad2Deg;
         Quaternion q = Quaternion.AngleAxis(steerAngle, Vector3.forward);
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
        if (CanDrive)
        {

            //   float Distance = Vector2.Distance(transform.position, destination);
            //
            //   if (Vector2.Distance(transform.position, destination) < 5)
            //   {
            //       transform.position += transform.up * Time.deltaTime * Vector2.Distance(transform.position, destination);
            //   }
            //   else transform.position += transform.up * Time.deltaTime * Acceleration;

            //car.AddForce(transform.up * Acceleration);
            //car.drag = 4 / Vector2.Distance(transform.position, destination);

            //float speed = 1 * Acceleration;
            //var direction = Mathf.Sign(Vector2.Dot(car.velocity, car.GetRelativeVector(Vector2.up)));
            //car.rotation += TurningSpeed * car.velocity.magnitude * direction;
            //
            //car.AddRelativeForce(Vector2.up * speed);
            //car.AddRelativeForce(-Vector2.right * car.velocity.magnitude * TurningSpeed / 2);
        }
    }

    private void Acceleration()
    {


    }

    private void Raycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 1);

        if (hit.collider != null && hit.collider.CompareTag("Horizontal Light"))
        {
            var trafficH = hit.collider.GetComponent<HorizontalLight>();
            if (trafficH.hcolorIm != 1)
            {
                CanDrive = false;
            }
            else CanDrive = true;
        }
        else if (hit.collider != null && hit.collider.CompareTag("Vertical Light"))
        {
            var trafficV = hit.collider.GetComponent<VerticalLight>();
            if (trafficV.vcolorIm != 1)
            {
                CanDrive = false;
            }
            else CanDrive = true;
        }
    }

    private void MeasureVelocity()
    {
        currentVelocity = ((transform.position - previousPosition).magnitude) * 3 / Time.deltaTime;
        previousPosition = transform.position;
        Debug.Log(currentVelocity);
    }

    public void SetDestination(Vector2 destination)
    {
        this.destination = destination;
        HasReachedDestination = false;
    }
}