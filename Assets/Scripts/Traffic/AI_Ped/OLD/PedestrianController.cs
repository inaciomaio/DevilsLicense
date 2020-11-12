using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianController : MonoBehaviour
{
    public float MovementSpeed = 1;

    public float RotationSpeed = 1;

    public float StopDistance = 2f;

    public bool HasReachedDestination;

    public Vector3 CurrentDestination;

    private Vector3 lastPosition;

    private Vector3 velocity;

    private void Awake()
    {
        MovementSpeed = Random.Range(0.5f, 2f);
    }

    public void SetDestination(Vector3 Destination)
    {
        CurrentDestination = Destination;
        HasReachedDestination = false;
    }

    private void FixedUpdate()
    {
        MoveToDestination();
        Debug.Log("Distance: " + Vector2.Distance(transform.localPosition, CurrentDestination));
    }

    private void MoveToDestination()
    {
        if (transform.position != CurrentDestination)
        {
            Vector3 destinationDirection = transform.position + CurrentDestination;
            Debug.DrawLine(transform.position, CurrentDestination, Color.red);
            destinationDirection.z = 0;
            float destinationDistance = Vector2.Distance(transform.position, CurrentDestination);

            if (destinationDistance > StopDistance)
            {
                HasReachedDestination = false;

                //Quaternion targetRotation = Quaternion.LookRotation(destinationDirection);

                Vector3 desiredRotation = CurrentDestination - transform.position;
                Quaternion targetRotation = Quaternion.LookRotation(desiredRotation, Vector2.up);
                Debug.Log(targetRotation);
                //transform.localRotation = targetRotation;//Quaternion.RotateTowards(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
                //transform.Translate(transform.right * MovementSpeed * Time.deltaTime);
                transform.position = Vector2.MoveTowards(transform.position, CurrentDestination, MovementSpeed);
                transform.LookAt(CurrentDestination);
            }
            else
            {
                Debug.Log("Reached destination");
                HasReachedDestination = true;
            }
        }

        lastPosition = transform.position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(CurrentDestination, 0.5f);

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.5f);

        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.localPosition, 0.5f);
    }
}