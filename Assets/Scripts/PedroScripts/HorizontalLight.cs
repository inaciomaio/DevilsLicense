using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class HorizontalLight : MonoBehaviour
{
    public IntersectionLights lightsManager;
    public int hcolorIm;
    private UnityEvent _prompt;
    private Manager _manager;

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
        hcolorIm = lightsManager.hcolor;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Car") && hcolorIm == 0)
        {
            Debug.Log("Stop the car !!!");
        }
        else if (collision.CompareTag("Car") && hcolorIm == 1)
        {
            _prompt.Invoke();

            //Make UI Appear
        }
    }
}
