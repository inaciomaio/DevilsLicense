using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour // This is the Local Level's Manager component
{
    //Level variables
    
    public float timeSlowSeconds = 0.5f;
    public static float T;
    public float timeScaleValue;
    public float distance;

    public int tlCooldown = 15;
    public int sCooldown = 10;

    public bool gameEnded;
    //Sign variables
    
    public static bool CanClickSign = false;
    public bool promptIsPossible = true;
    public bool changeSignIsPossible = true;
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
    public GameObject power2;
    
    public GameObject veloc30;
    public GameObject veloc50;

    private GameObject error0;
    private GameObject error1;
    private GameObject error2;
    public GameObject instructions;

    private GlobalManager _globalManager;
    public CarAI _carAi;
    public GameObject stars;
    public Transform starsPoint;

    public int speed = 10;
    public int currentSceneIndex;
    public Pause pause;
    void Awake()
    {
        Time.timeScale = 1;
        _globalManager = GameObject.Find("GlobalManager").GetComponent<GlobalManager>();
        _globalManager.manager = gameObject.GetComponent<Manager>();
        prompt = GameObject.Find("Prompt");
        car = GameObject.Find("Player");
        destination = GameObject.Find("Destination");
        gameOverUi = GameObject.Find("GameOverUi");
        tempUi = GameObject.Find("TempUi");
        power1 = GameObject.Find("Power1");
        power2 = GameObject.Find("Power2");
        stars = GameObject.Find("StarsScore");
        starsPoint = GameObject.Find("StarsPoint").GetComponent<Transform>();
        
        error0 = GameObject.Find("0error");
        error1 = GameObject.Find("1error");
        error2 = GameObject.Find("2error");
        _carAi = car.GetComponent<CarAI>();
        prompt.SetActive(false);
        gameOverUi.SetActive(false);
        instructions = GameObject.Find("Instructions");

        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        pause = gameObject.GetComponent<Pause>();
        StartCoroutine(InstructionPopUp());
    }
    
    void Start()
    {
        Application.targetFrameRate = 60;
        distance = Vector3.Distance(destination.transform.position, car.transform.position);
        
        error0.SetActive(false);
        error1.SetActive(false);
        error2.SetActive(false);
        
        veloc30 = GameObject.Find("30pont");
        veloc50 = GameObject.Find("50pont");
    }
    
    void Update()
    {
        if (_carAi.TargetSpeed <= 6)
        {
            veloc30.SetActive(true);
            veloc50.SetActive(false);
        }
        else
        {
            veloc30.SetActive(false);
            veloc50.SetActive(true);
        }
        
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

        if (changeSignIsPossible)
        {
            power2.SetActive(true);
        }
        else
        {
            power2.SetActive(false);
        }

        if (pause.IsPaused == false)
        {
            T += Time.deltaTime;
        }
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
        pause.isAbleToPause = false;
        promptIsPossible = false;
        Time.timeScale = timeScaleValue;
        prompt.SetActive(true);
        yield return new WaitForSecondsRealtime(timeSlowSeconds);
        yield return Time.timeScale = 1f;
        StartCoroutine(ChangeLightsCooldown());
        prompt.SetActive(false);
        promptIsPossible = true;
        pause.isAbleToPause = true;
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
        yield return new WaitForSecondsRealtime(tlCooldown); // Power cooldown (can be changed)
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

    IEnumerator InstructionPopUp()
    {
        Time.timeScale = 0;
        instructions.SetActive(true);
        pause.isAbleToPause = false;
        yield return new WaitForSecondsRealtime(90);
        instructions.SetActive(false);
        Time.timeScale = 1;
        pause.isAbleToPause = true;
    }
}
