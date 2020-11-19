using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class texttimer : MonoBehaviour
{
    public Text timer;
    public float t;
    public float treset;
    void Start()
    {
        timer = gameObject.GetComponent<Text>();
    }

    
    void Update()
    {
        t += Time.deltaTime;
        treset += Time.deltaTime;

        if (treset > 10)
        {
            treset = 0;
        }
        
        timer.text = "Elapsed Time:" + " " + t.ToString() + "\n" + "Timer:" + " " + treset.ToString() + "\n" + "FPS:" + " " + (1/Time.deltaTime);
    }
}
