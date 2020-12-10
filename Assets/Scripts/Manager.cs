using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 *  This Script is the Manager of each Level (Is deletable)
 */

public class Manager : MonoBehaviour
{
    public float timeSlowSeconds = 2.5f;
    public static float T;
    public float timeScaleValue;
    public float distance;
    
    public bool promptIsPossible = true;
    public bool changeLightsIsPossible = true;

    public int errorCount = 0;

    public GameObject gameOverUi;
    public GameObject prompt; //Traffic Light Prompt
    public GameObject car; //Current
    public GameObject destination; //Final
    public GameObject tempUi; //All UI that won't be available at game over screen
    public GameObject power1;

    public int currentSceneIndex;
    void Awake()
    {
        Time.timeScale = 1;
        prompt = GameObject.Find("Prompt");
        car = GameObject.Find("Player");
        destination = GameObject.Find("Destination");
        gameOverUi = GameObject.Find("GameOverUi");
        tempUi = GameObject.Find("TempUi");
        power1 = GameObject.Find("Power1");

        prompt.SetActive(false);
        gameOverUi.SetActive(false);
        
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    
    void Start()
    {
        Application.targetFrameRate = 60;
        distance = Vector3.Distance(destination.transform.position, car.transform.position);
    }
    
    void Update()
    {
        if (changeLightsIsPossible)
        {
            power1.SetActive(true);
        }
        else
        {
            power1.SetActive(false);
        }

        T += Time.deltaTime;
        distance = Vector3.Distance(destination.transform.position, car.transform.position);

        if (errorCount >= 3)
        {
            OnGameOverMthd();
        }
    }

    public void OnGameOverMthd()
    {
        StartCoroutine(OnGameOver());
    }
    
    public void OnGreenLight()
    {
        Debug.Log("Found Manager");
        
        StartCoroutine("GreenLightUIPrompt");
    }

    public void OnSign()
    {
        Debug.Log("Sign Call");
        StartCoroutine("SignUIPrompt");
    }
    
    //

    IEnumerator GreenLightUIPrompt()
    {
        promptIsPossible = false;
        Time.timeScale = timeScaleValue;
        prompt.SetActive(true);
        yield return new WaitForSecondsRealtime(timeSlowSeconds);
        StartCoroutine(ChangeLightsCooldown());
        prompt.SetActive(false);
        promptIsPossible = true;
        yield return Time.timeScale = 1f;
    }

    /*IEnumerator SignUIPrompt()
    {
        promptIsPossible = false;
        Time.timeScale = 0.1f;
        signprompt.SetActive(true);
        yield return new WaitForSecondsRealtime(5);
        signprompt.SetActive(false);
        promptIsPossible = true;
        yield return Time.timeScale = 1f;
    }*/
    
    //

    IEnumerator ChangeLightsCooldown()  
    {
        yield return new WaitForSecondsRealtime(2); // Power cooldown (can be changed)
        yield return changeLightsIsPossible = true;
    }
    
    IEnumerator OnGameOver()
    {
        Time.timeScale = 0;
        tempUi.SetActive(false);
        gameOverUi.SetActive(true);
        yield return new WaitForSecondsRealtime(180);
        errorCount = 0;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
