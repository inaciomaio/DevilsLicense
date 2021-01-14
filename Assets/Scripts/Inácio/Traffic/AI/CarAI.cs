using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAI : MonoBehaviour
{

    [Range(30, 85)]
    public int MaxVelocity = 85;

    [Range(0, 5)]
    public float EnginePower = 2f;

    public float TurningSpeed = 2f;

    public float BreakingPower = 5f;

    public float BreakingDistance = 50f;

    public float CurrentVelocity;

    private Rigidbody2D car;

    private Vector2 destination;

    private Vector3 previousPosition;

    public bool HasReachedDestination;

    public bool CanDrive = true;

    private void Awake()
    {
        car = GetComponent<Rigidbody2D>();
        Vector3 previousPosition = transform.position;
        Physics2D.queriesStartInColliders = false;
    }

    private void Update()
    {
        MeasureVelocity();
        AimToWaypoint();
        MinDstToWaypoint();
        Raycast();
        Drive();
    }

     private void AimToWaypoint()
     {
         Vector3 target = new Vector3(destination.x, destination.y);
         Vector3 destinationVector = target - transform.position;
         float steerAngle = Mathf.Atan2(-destinationVector.x, destinationVector.y) * Mathf.Rad2Deg;
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
            float percentageOfMax = Vector2.Distance(transform.position, destination) / BreakingDistance;
            
            percentageOfMax = Mathf.Clamp01(percentageOfMax);
            
            float speed = Mathf.Lerp(1.5f, 10, percentageOfMax) * EnginePower;
            
            transform.position += transform.up * Time.deltaTime * speed;


            //car.AddRelativeForce(Vector2.up * speed * Time.deltaTime);


            //Debug.DrawRay(transform.position, transform.up * 10);
            //float distance = Vector2.Distance(transform.position, destination);
            //float trueDistance = Mathf.Lerp(0, 1, distance); 
            //float speed = 100 * EnginePower;
            ////speed = Mathf.Lerp(5, 1, Vector2.Distance(transform.position, destination));
            ////car.AddRelativeForce(Vector2.up * speed);
            ////Debug.Log(speed);
            //
            //
            //
            //
            //
            //transform.position += transform.up * Time.deltaTime * EnginePower;

            // float Distance = Vector2.Distance(transform.position, destination);
            // 
            // if (Vector2.Distance(transform.position, destination) < 2)
            // {
            //     transform.position += transform.up * Time.deltaTime * Distance;
            // }
            // else transform.position += transform.up * Time.deltaTime * EnginePower;

            //car.AddForce(transform.up * Acceleration);
            //car.drag = 4 / Vector2.Distance(transform.position, destination);


            //var direction = Mathf.Sign(Vector2.Dot(car.velocity, car.GetRelativeVector(Vector2.up)));
            //car.rotation += TurningSpeed * car.velocity.magnitude * direction;

        }
    }


    private void Raycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 1.5f);
        Debug.DrawRay(transform.position, transform.up * 1.5f, Color.red);

        if (hit.collider != null && hit.collider.CompareTag("Car") || hit.collider != null && hit.collider.CompareTag("Player"))
        {
            CanDrive = false;
        }
        else CanDrive = true;

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
        CurrentVelocity = ((transform.position - previousPosition).magnitude) * 3 / Time.deltaTime;
        previousPosition = transform.position;
        Debug.Log("Speed " + CurrentVelocity);
    }

    public void SetDestination(Vector2 destination)
    {
        this.destination = destination;
        HasReachedDestination = false;
    }
}