using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    void Awake()
    {
        if (GameObject.Find("Manager") != null)
        {
            Destroy(this);
        }
    }

    void Update()
    {

    }

    public void Debuglog()
    {
        Debug.Log("Found Manager");
    }
}
