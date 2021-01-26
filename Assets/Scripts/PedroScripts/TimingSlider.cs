using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimingSlider : MonoBehaviour
{
    public Slider timingSliderSl;
    public GameObject car;
    [SerializeField]
    public GameObject signPointSl;

    public float distanceTs;

    public bool canCalculate = false;

    void Awake()
    {
        car = GameObject.Find("CarPoint");
        timingSliderSl = gameObject.GetComponent<Slider>();
        
    }
    void Update()
    {
        if (canCalculate)
        {
            distanceTs = Vector3.Distance(car.transform.position, signPointSl.transform.position);
            timingSliderSl.value = timingSliderSl.maxValue - distanceTs;
        }
        else
        {
            distanceTs = 0;
        }
        
    }
}
