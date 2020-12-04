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

    void Awake()
    {
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
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Car") && vcolorIm == 0)
        {
            Debug.Log("Stop the car !!!");
        }
        else if (collision.CompareTag("Car") && vcolorIm == 1)
        {
            _prompt.Invoke();
            //Make UI Appear
        }
    }
}
