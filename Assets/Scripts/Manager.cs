using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour // This is the Local Level's Manager component
{
    //Level variables
    
    public float timeSlowSeconds = 2.5f;
    public static float T;
    public float timeScaleValue;
    public float distance;

    private bool gameEnded;
    //Sign variables
    
    public static bool CanClickSign = false;
    public bool promptIsPossible = true;
    public bool changeLightsIsPossible = true;

    //Level error Counter
    
    public int errorCount = 0;

    //GameObjects

    public GameObject gameOverUi;
    public GameObject prompt; //Traffic Light Prompt
    public GameObject car; //Current
    public GameObject destination; //Final
    public GameObject tempUi; //All UI that won't be available at game over screen
    public GameObject power1;

    private GameObject error0;
    private GameObject error1;
    private GameObject error2;
    private CarAI _carAi;
    public GameObject stars;
    public Transform starsPoint;

    public int speed = 10;
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
        stars = GameObject.Find("StarsScore");
        starsPoint = GameObject.Find("StarsPoint").GetComponent<Transform>();
        
        error0 = GameObject.Find("0error");
        error1 = GameObject.Find("1error");
        error2 = GameObject.Find("2error");
        _carAi = car.GetComponent<CarAI>();
        prompt.SetActive(false);
        gameOverUi.SetActive(false);
        
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    
    void Start()
    {
        Application.targetFrameRate = 60;
        distance = Vector3.Distance(destination.transform.position, car.transform.position);
        
        error0.SetActive(false);
        error1.SetActive(false);
        error2.SetActive(false);
    }
    
    void Update()
    {
        if (CanClickSign)
        {
            Debug.Log("CANCLICKSIGN");
        }
        
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

        switch (errorCount)
        {
            case 1:
                error2.SetActive(true);
                break;
            case 2:
                error1.SetActive(true);
                break;
            case 3:
                error0.SetActive(true);
                break;
        }

        if (errorCount >= 3)
        {
            gameEnded = true;
            OnGameOverMthd();
        }
    }

    public void OnGameOverMthd()
    {
        gameEnded = true;
        if (gameEnded)
        {
            StartCoroutine(OnGameOver());
        }
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
        yield return new WaitForSecondsRealtime(10); // Power cooldown (can be changed)
        yield return changeLightsIsPossible = true;
    }
    
    IEnumerator OnGameOver()
    {
        _carAi.CanDrive = false;
        StartCoroutine(MoveStars());
        tempUi.SetActive(false);
        gameOverUi.SetActive(true);
        yield return new WaitForSecondsRealtime(180);
        errorCount = 0;
        SceneManager.LoadScene(currentSceneIndex);
    }
    
    IEnumerator MoveStars()
    {
        LeanTween.move(stars, starsPoint, 0.3f);
        yield break;
    }
}
