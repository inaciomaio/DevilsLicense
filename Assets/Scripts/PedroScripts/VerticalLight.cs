using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class VerticalLight : MonoBehaviour
{
    public IntersectionLights lightsManager;
    public int vcolorIm;
    private UnityEvent _prompt;
    private Manager _manager;
    private CarAI car;
    
    public bool hasCollided;
    public bool hasLeft;

    void Awake()
    {
        car = GameObject.FindWithTag("Player").GetComponent<CarAI>();
        transform.gameObject.tag = "RedLight";
        lightsManager = GameObject.Find("IntersectionLM").GetComponent<IntersectionLights>();
    }
    
    void Start()
    {
        if (GameObject.Find("Manager") != null)
        {
            _manager = GameObject.Find("Manager").GetComponent<Manager>();
            _prompt = new UnityEvent();
            _prompt.AddListener(_manager.OnGreenLight);
        }
        else
        {
            throw new Exception("No Manager object found, return to Main Menu.");
        }
    }
    
    void Update()
    {
        vcolorIm = lightsManager.vcolor;

        if (vcolorIm != 0)
        {
            transform.gameObject.tag = "GreenLight";
        }
        else if (vcolorIm != 1)
        {
            transform.gameObject.tag = "RedLight";
        }
        
        if(hasCollided && hasLeft && lightsManager.hasClicked)
        {
            _manager.errorCount++;
            hasCollided = false;
            lightsManager.hasClicked = false;
        }
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        hasLeft = false;
        hasCollided = true;
        if (collision.CompareTag("Player") && vcolorIm == 1 && _manager.promptIsPossible && _manager.changeLightsIsPossible)
        {
            //Make Prompt UI Appear
            _prompt.Invoke();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && lightsManager.hasClicked)
        {
            StartCoroutine(Stop());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        hasLeft = true;
    }
    IEnumerator Stop()
    {
        lightsManager.hasClicked = false;
        car.CanDrive = false;
        yield return new WaitForSeconds(10);
        car.CanDrive = true;
    }
}
