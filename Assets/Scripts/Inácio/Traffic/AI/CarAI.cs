using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarAI : MonoBehaviour
{
    private NavMeshAgent agent;

    public Vector3 targetDestination;

    // navMeshWaypoint != waypoints

    private WaypointManager waypoint;

    private string currentRoad;
    private RoadManager road;
    private bool MoveAcrossNavMeshHasStarted;

    private int testIndex = 0;

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

    private void Update()
    {
        //Debug.Log(transform.name + "is" + agent.isStopped);
        //Test();
        RaycastCheckForCars();
        CustomTraverseNavMeshLink();
        //TurnToCorner();
        //CheckRoadVelocity();
    }

    private void Test()
    {
        Vector2 v = agent.velocity;
        var angle = Mathf.Atan2(v.x, v.y) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void RaycastCheckForCars()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + transform.up * 3, transform.position + transform.up);
        Debug.DrawLine(transform.position + transform.up * 3, transform.position + transform.up, Color.red);

        if (hit.collider != null && hit.collider.CompareTag("Car"))
        {
            agent.isStopped = true;
        }
        else agent.isStopped = false;
    }

    private void CustomTraverseNavMeshLink()
    {
        if (agent.isOnOffMeshLink && !MoveAcrossNavMeshHasStarted)
        {
            StartCoroutine("TraverseNavMeshLink");
            MoveAcrossNavMeshHasStarted = true;
        }
    }

    private IEnumerator TraverseNavMeshLink()
    {
        var saveRotation = transform.rotation;
        OffMeshLinkData data = agent.currentOffMeshLinkData;
        Vector3 oldVelocity = agent.velocity;
        Vector3 startPos = agent.transform.position;
        Vector3 endPos = data.endPos + Vector3.up * agent.baseOffset;
        float duration = (endPos - startPos).magnitude / agent.velocity.magnitude;
        float t = 0.0f;
        float tStep = 1.0f / duration;
        while (t < 1.0f)
        {
            transform.rotation = saveRotation;
            transform.position = Vector3.Lerp(startPos, endPos, t);
            t += tStep * Time.deltaTime;
            yield return null;
        }
        transform.position = endPos;
        agent.CompleteOffMeshLink();
        agent.velocity = oldVelocity;
        MoveAcrossNavMeshHasStarted = false;
    }

    private void CheckRoadVelocity()
    {
        Debug.Log(transform.name + agent.speed);
        Ray ray = new Ray(transform.position + transform.forward, transform.forward);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, 10);

        if (hit.collider != null)
        {
            currentRoad = hit.transform.name;
            Debug.LogError(currentRoad);

            if (currentRoad != hit.transform.name)
            {
                currentRoad = hit.transform.name;
                agent.speed = Random.Range(1, hit.transform.GetComponent<RoadManager>().MaxVelocity);
            }
        }
    }
}