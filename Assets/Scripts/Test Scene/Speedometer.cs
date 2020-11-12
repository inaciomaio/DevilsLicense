using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    public test test;
    public GameObject Car;
    public Vector3 lastPosition;
    public float distanceTravelled;
    public TextMeshProUGUI OnScreenSpeed;

    void Start()
    {
        lastPosition = Car.transform.position;
    }

    void Update()
    {
        distanceTravelled += Vector3.Distance(Car.transform.position, lastPosition);
        lastPosition = Car.transform.position;
        OnScreenSpeed.text = Mathf.CeilToInt(distanceTravelled).ToString() + " " + "meters";
    }
}
