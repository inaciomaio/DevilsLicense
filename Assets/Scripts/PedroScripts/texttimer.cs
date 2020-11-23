using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class texttimer : MonoBehaviour
{
    public Text timer;
    public float t;
    void Start()
    {
        timer = gameObject.GetComponent<Text>();
    }
    
    void Update()
    {
        t += Time.deltaTime;

        timer.text = "Elapsed Time:" + " " + t.ToString() + "\n" + "Manager.T:" + " " + Manager.T.ToString() + "\n" + "FPS:" + " " + (1/Time.deltaTime);
    }
}
