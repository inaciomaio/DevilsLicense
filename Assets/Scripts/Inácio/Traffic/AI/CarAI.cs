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

    public float BreakingPower = 5f;

    public float BreakingDistance = 50f;

    private Vector2 destination;

    private Vector3 previousPosition;

    public bool HasReachedDestination;

    private Rigidbody2D car;

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
            float speed = 100 * EnginePower;

            float percentageOfMax = Vector2.Distance(transform.position, destination) / BreakingDistance;

            percentageOfMax = Mathf.Clamp01(percentageOfMax);

             speed = Mathf.Lerp(1.5f, 10, percentageOfMax);

            transform.position += transform.up * Time.deltaTime * speed;
















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