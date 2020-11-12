using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    public float TimeUntilChange = 10;

    public int Color = 0;

    // Update is called once per frame
    private void Start()
    {
        StartCoroutine(TrafficLights());
    }

    private IEnumerator TrafficLights()
    {
        while (true)
        {
            if (Color == 2)
            {
                Color = 1;
                Debug.Log("It's Yellow");
                yield return new WaitForSeconds(TimeUntilChange / 3);
                Color = 0;
                Debug.Log("It's Red");
            }
            else
            {
                yield return new WaitForSeconds(TimeUntilChange);
                Color = 2;
                Debug.Log("It's Green");
                yield return new WaitForSeconds(TimeUntilChange);
            }
        }
    }
}