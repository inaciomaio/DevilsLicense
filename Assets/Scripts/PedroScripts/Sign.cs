using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Sign : MonoBehaviour
{
    public int signId; //Change in Inspector according to Sign/Sprite
    
    private UnityEvent _signprompt;
    private Manager _manager;

    void Start()
    {
        if (GameObject.Find("Manager") != null)
        {
            _manager = GameObject.Find("Manager").GetComponent<Manager>();
            _signprompt = new UnityEvent();
            _signprompt.AddListener(_manager.OnSign);
        }
        else
        {
            throw new Exception("No Manager object found, return to Main Menu.");
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Car") && _manager.promptIsPossible)
        {
            _signprompt.Invoke();
        }
    }
}
