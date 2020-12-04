using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceSlider : MonoBehaviour
{
    /*
     * Slider's maxValue should be changed in the Inspector
     */
    
    public Slider distanceSlider;
    public Manager managerGo;

    void Start()
    {
        managerGo = GameObject.Find("Manager").GetComponent<Manager>();
    }

    void Update()
    {
        distanceSlider.value = distanceSlider.maxValue - managerGo.distance;
    }
}
