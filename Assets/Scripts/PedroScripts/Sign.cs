using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

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

    public GameObject timingSlidergo;
    public TimingSlider timingSlider;
    public GameObject signPoint;
    
    public GameObject StopWheel;

    public bool pressedInTime;
    //Other objects

    private WaypointNavigator navigator;
    private CarAI car;

    [Header("TurnSign Properties")]
    public Waypoint currentWaypointForward;
    public Waypoint currentWaypointLeft;
    public Waypoint currentWaypointRight;
    public bool CanNPCsUseForward;
    public bool CanNPCsUseLeft;
    public bool CanNPCsUseRight;

    //[Header("ChangeRoadTargetSpeed Properties")]
    //public bool Thirty;
    //public List<Waypoint> WaypointsToChange = new List<Waypoint>();


    void Awake()
    {
        StopWheel.SetActive(false);

        timingSlidergo = GameObject.Find("TimingSlider");
        timingSlider = GameObject.Find("TimingSlider").GetComponent<TimingSlider>();
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

        if (signId > 6)
        {
            signId = 0;
        }
    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        StopWheel.SetActive(false);
        _manager.promptIsPossible = true;
        Time.timeScale = 1f;
        NullifyTimingSlider();
        if (_manager.promptIsPossible && pressedInTime == false) //ErrorCount timing
        {
            car = collision.GetComponent<CarAI>();
            switch (signId)
            {
                case 0:
                    //Stop sign Function
                    if (collision.CompareTag("Car") | collision.CompareTag("Player"))
                    {
                        StartCoroutine(Stop());
                    }
                    break;
                case 1:
                    //TurnLeft sign Function
                    if (CanNPCsUseLeft && currentWaypointLeft != null)
                    {
                        if (collision.CompareTag("Car") | collision.CompareTag("Player"))
                        {
                            navigator = collision.GetComponent<WaypointNavigator>();
                            navigator.currentWaypoint = currentWaypointLeft;
                            car.SetDestination(currentWaypointLeft.GetPosition());
                        }

                    }
                    else if (collision.CompareTag("Player") && currentWaypointLeft != null)
                    {
                        navigator = collision.GetComponent<WaypointNavigator>();
                        navigator.currentWaypoint = currentWaypointLeft;
                        car.SetDestination(currentWaypointLeft.GetPosition());
                    }
                    break;
                case 2:
                    if (CanNPCsUseForward && currentWaypointForward != null)
                    {
                        if (collision.CompareTag("Car") | collision.CompareTag("Player"))
                        {
                            navigator = collision.GetComponent<WaypointNavigator>();
                            navigator.currentWaypoint = currentWaypointForward;
                            car.SetDestination(currentWaypointForward.GetPosition());
                        }

                    }
                    else if (collision.CompareTag("Player") && currentWaypointForward != null)
                    {
                        navigator = collision.GetComponent<WaypointNavigator>();
                        navigator.currentWaypoint = currentWaypointForward;
                        car.SetDestination(currentWaypointForward.GetPosition());
                    }
                    break;
                case 3:
                    //TurnRight sign Function
                    if (CanNPCsUseRight && currentWaypointRight != null)
                    {
                        if (collision.CompareTag("Car") | collision.CompareTag("Player"))
                        {
                            navigator = collision.GetComponent<WaypointNavigator>();
                            navigator.currentWaypoint = currentWaypointRight;
                            car.SetDestination(currentWaypointRight.GetPosition());
                        }

                    }
                    else if (collision.CompareTag("Player") && currentWaypointRight != null)
                    {
                        navigator = collision.GetComponent<WaypointNavigator>();
                        navigator.currentWaypoint = currentWaypointRight;
                        car.SetDestination(currentWaypointRight.GetPosition());
                    }
                    break;
                case 4:
                    if (car == null)
                    {
                        return;
                    }
                    else
                    {
                        car.TargetSpeed = 5f;
                    }
                    break;
                case 5:
                    if (car == null)
                    {
                        return;
                    }
                    else
                    {
                        car.TargetSpeed = 8.3333333f;

                    }
                    break;
            }
        }
    }

   //ALTERNATIVE WAY 
   // public void ChangeSpeed(float speed)
   // {
   //     foreach (var Waypoint in WaypointsToChange)
   //     {
   //         Waypoint.TargetSpeed = speed;a
   //     }
   // }

   
   public void OnButtonClick()
    {
        if (Manager.CanClickSign && _manager.changeSignIsPossible)
        {
            timingSlider.canCalculate = true;
            StartCoroutine(StopWheelCR());
            timingSlider.signPointSl = signPoint;
        }
    }

    public void LeftButtonClicked()
    {
        _manager.changeSignIsPossible = false;
        StartCoroutine(ChangeSignCooldown());
        if (timingSlidergo.GetComponent<Slider>().value > 4.2f) //ErrorCount timing
        {
            _manager.errorCount++;
            pressedInTime = true;
        }
        NullifyTimingSlider();
        signId = 1;
        StopWheel.SetActive(false);
        _manager.promptIsPossible = true;
        Time.timeScale = 1f;
        _manager.pause.isAbleToPause = true;
    }

    public void ForwardButtonClicked()
    {
        _manager.changeSignIsPossible = false;
        StartCoroutine(ChangeSignCooldown());
        if (timingSlidergo.GetComponent<Slider>().value > 4.2f) //ErrorCount timing
        {
            _manager.errorCount++;
            pressedInTime = true;
        }
        NullifyTimingSlider();
        signId = 2;
        StopWheel.SetActive(false);
        _manager.promptIsPossible = true;
        Time.timeScale = 1f;
        _manager.pause.isAbleToPause = true;
    }

    public void RightButtonClicked()
    {
        _manager.changeSignIsPossible = false;
        StartCoroutine(ChangeSignCooldown());
        if (timingSlidergo.GetComponent<Slider>().value > 4.2f) //ErrorCount timing
        {
            _manager.errorCount++;
            pressedInTime = true;
        }
        NullifyTimingSlider();
        signId = 3;
        StopWheel.SetActive(false);
        _manager.promptIsPossible = true;
        Time.timeScale = 1f;
        _manager.pause.isAbleToPause = true;
    }
    
    public void FiftyButtonClicked()
    {
        _manager.changeSignIsPossible = false;
        StartCoroutine(ChangeSignCooldown());
        if (timingSlidergo.GetComponent<Slider>().value > 4.2f) //ErrorCount timing
        {
            _manager.errorCount++;
            pressedInTime = true;
        }
        NullifyTimingSlider();
        signId = 5;
        StopWheel.SetActive(false);
        _manager.promptIsPossible = true;
        Time.timeScale = 1f;
        _manager.pause.isAbleToPause = true;
    }

    public void ThirtyButtonClicked()
    {
        _manager.changeSignIsPossible = false;
        StartCoroutine(ChangeSignCooldown());
        if (timingSlidergo.GetComponent<Slider>().value > 4.2f) //ErrorCount timing
        {
            _manager.errorCount++;
            pressedInTime = true;
        }
        NullifyTimingSlider();
        signId = 4;
        StopWheel.SetActive(false);
        _manager.promptIsPossible = true;
        Time.timeScale = 1f;
        _manager.pause.isAbleToPause = true;
    }

    public void CwButtonClicked()
    {
        NullifyTimingSlider();
        signId = 6;
        StopWheel.SetActive(false);
        _manager.promptIsPossible = true;
        Time.timeScale = 1f;
        _manager.pause.isAbleToPause = true;
    }

    public void StopButtonClicked()
    {
        
        _manager.changeSignIsPossible = false;
        StartCoroutine(ChangeSignCooldown());
        if (timingSlidergo.GetComponent<Slider>().value > 4.2f) //ErrorCount timing
        {
            _manager.errorCount++;
            pressedInTime = true;
        }
        NullifyTimingSlider();
        signId = 0;
        StopWheel.SetActive(false);
        _manager.promptIsPossible = true;
        Time.timeScale = 1f;
        _manager.pause.isAbleToPause = true;
    }

    IEnumerator StopWheelCR()
    {
        _manager.promptIsPossible = false;
        _manager.pause.isAbleToPause = false;
        Time.timeScale = 0.1f;
        StopWheel.SetActive(true);
        yield return new WaitForSecondsRealtime(6);
        if (pressedInTime) //ErrorCount timing
        {
            StartCoroutine(ResetTimingVar());
        }
        NullifyTimingSlider();
        StopWheel.SetActive(false);
        _manager.promptIsPossible = true;
        yield return Time.timeScale = 1f;
        _manager.pause.isAbleToPause = true;
    }

    //Required for StopSign
    private IEnumerator Stop()
    {
        car.TargetSpeed = 0;
        yield return new WaitForSeconds(3);
        car.TargetSpeed = 8.3333333f;
    }

    IEnumerator ResetTimingVar() //ErrorCount timing
    {
        yield return new WaitForSecondsRealtime(2);
        yield return pressedInTime = false;
    }

    IEnumerator ChangeSignCooldown()
    {
        yield return new WaitForSecondsRealtime(_manager.sCooldown);
        yield return _manager.changeSignIsPossible = true;
    }

    void NullifyTimingSlider()
    {
        timingSlider.canCalculate = false;
        timingSlider.signPointSl = null;
        timingSlider.timingSliderSl.value = 0;
    }
}
