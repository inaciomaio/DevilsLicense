using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public float timeSlowSeconds = 2.5f;
    public static float T;
    public float timeScaleValue;

    void Start()
    {
        Application.targetFrameRate = 60;
    }
    
    void Update()
    {
        T += Time.deltaTime;
    }
    
    public void OnGreenLight()
    {
        Debug.Log("Found Manager");
        
        StartCoroutine("GreenLightUIPrompt");
    }

    IEnumerator GreenLightUIPrompt()
    {
        Time.timeScale = timeScaleValue;
        yield return new WaitForSecondsRealtime(timeSlowSeconds);
        yield return Time.timeScale = 1f;
    }
}
