using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelEnd : MonoBehaviour
{
    private Manager _manager;
    private UnityEvent _gameOver;

    
    void Start()
    {
        _manager = GameObject.Find("Manager").GetComponent<Manager>();
        _gameOver = new UnityEvent();
        _gameOver.AddListener(_manager.OnGameOverMthd);
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _gameOver.Invoke();
        }
    }    
}


