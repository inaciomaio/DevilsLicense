using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public float timeSlowSeconds = 2.5f;
    public static float T;
    public float timeScaleValue;
    public float distance;

    public GameObject prompt;
    public GameObject car;
    public GameObject destination;
    void Awake()
    {
        prompt = GameObject.Find("Prompt"); //Test
        car = GameObject.Find("Car");
        destination = GameObject.Find("Destination");
    }
    
    void Start()
    {
        Application.targetFrameRate = 60;
        
        prompt.SetActive(false);
        
        distance = Vector3.Distance(destination.transform.position, car.transform.position);
    }
    
    void Update()
    {
        T += Time.deltaTime;
        distance = Vector3.Distance(destination.transform.position, car.transform.position);
    }
    
    public void OnGreenLight()
    {
        Debug.Log("Found Manager");
        
        StartCoroutine("GreenLightUIPrompt");
    }

    IEnumerator GreenLightUIPrompt()
    {
        Time.timeScale = timeScaleValue;
        prompt.SetActive(true);
        yield return new WaitForSecondsRealtime(timeSlowSeconds);
        prompt.SetActive(false);
        yield return Time.timeScale = 1f;
    }
}
