using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
 * Stop (Id=0)
 * Left (Id=1)
 * Forward (Id=2)
 * Right (Id=3)
 * 30 (Id=4)
 * 50 (Id=5)
 * Crosswalk (Id=6)
 */

public class Sign : MonoBehaviour
{
    public int signId; //Change in Inspector according to Sign desired
    
    private UnityEvent _signprompt;
    private Manager _manager;
    private SpriteRenderer _sR;

    public Sprite rightspr;
    public Sprite forwardspr;
    public Sprite leftspr;
    public Sprite stopspr;
    public Sprite speed30spr;
    public Sprite speed50spr;
    public Sprite cwspr;

    public GameObject StopWheel;
    //Other objects

    void Awake()
    {
        StopWheel.SetActive(false);
    }
    
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

        _sR = gameObject.GetComponent<SpriteRenderer>();

        rightspr = Resources.Load<Sprite>("Sprites/sinal-direita");
        forwardspr = Resources.Load<Sprite>("Sprites/sinal-frente");
        leftspr = Resources.Load<Sprite>("Sprites/sinal-esquerda");
        stopspr = Resources.Load<Sprite>("Sprites/sinal-stop");
        speed30spr = Resources.Load<Sprite>("Sprites/sinal-limite30");
        speed50spr = Resources.Load<Sprite>("Sprites/sinal-limite50");
        cwspr = Resources.Load<Sprite>("Sprites/sinal-passadeira");
    }

    void Update()
    {
        switch (signId)
        {
            case 0:
                _sR.sprite = stopspr;
                break;
            case 1:
                _sR.sprite = leftspr;
                break;
            case 2:
                _sR.sprite = forwardspr;
                break;
            case 3:
                _sR.sprite = rightspr;
                break;
            case 4:
                _sR.sprite = speed30spr;
                break;
            case 5:
                _sR.sprite = speed50spr;
                break;
            case 6:
                _sR.sprite = cwspr;
                break;
        }

        if (signId > 5)
        {
            signId = 0;
        }
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Car") && _manager.promptIsPossible)
        {
            switch (signId)
            {
                case 0:
                    //Stop function
                    break;
                case 1:
                    //Left function
                    break;
                case 2:
                    //Forward function
                    break;
                case 3:
                    //Right function
                    break;
                case 4:
                    //30speed function
                    break;
                case 5:
                    //50speed function
                    break;
            }
        }
    }

    public void OnButtonClick()
    {
        StartCoroutine(StopWheelCR());
    }

    public void LeftButtonClicked()
    {
        signId = 1;
        _manager.promptIsPossible = true;
        Time.timeScale = 1f;
    }

    public void ForwardButtonClicked()
    {
        signId = 2;
        _manager.promptIsPossible = true;
        Time.timeScale = 1f;
    }

    public void RightButtonClicked()
    {
        signId = 3;
        _manager.promptIsPossible = true;
        Time.timeScale = 1f;
    }
    
    public void FiftyButtonClicked()
    {
        signId = 5;
        _manager.promptIsPossible = true;
        Time.timeScale = 1f;
    }

    public void ThirtyButtonClicked()
    {
        signId = 4;
        _manager.promptIsPossible = true;
    }

    public void CwButtonClicked()
    {
        signId = 6;
        _manager.promptIsPossible = true;
    }

    public void StopButtonClicked()
    {
        signId = 0;
        _manager.promptIsPossible = true;
    }

    IEnumerator StopWheelCR()
    {
        _manager.promptIsPossible = false;
        Time.timeScale = 0.1f;
        StopWheel.SetActive(true);
        yield return new WaitForSecondsRealtime(3);
        StopWheel.SetActive(false);
        _manager.promptIsPossible = true;
        yield return Time.timeScale = 1f;
    }
}
