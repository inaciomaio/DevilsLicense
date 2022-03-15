using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSign : MonoBehaviour
{
    private CarAI car;

    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        car = collision.GetComponent<CarAI>();
        car.CanDrive = false;
        StartCoroutine("Stop");
    }

    private IEnumerator Stop()
    {
        yield return new WaitForSeconds(5);
        car.CanDrive = true;
    }
}