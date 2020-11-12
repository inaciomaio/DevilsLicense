using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class RaycastCarAI : MonoBehaviour
{
    private void Update()
    {
        CheckWallDistance();
        //Drive();
    }

    private void Drive()
    {
        transform.position += new Vector3(0, 1);
    }

    private void CheckWallDistance()
    {
        RaycastHit2D right = Physics2D.Raycast(transform.position, transform.position * .5f);

        if (right.collider)
        {
            Debug.Log(right.distance + right.collider.name);
        }
    }
}