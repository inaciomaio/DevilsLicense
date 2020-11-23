using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    public GameObject manager;
    void Awake()
    {
        if (GameObject.Find("Manager") == null)
        {
            Instantiate(manager);
            GameObject.Find("Manager(Clone)").name = "Manager";
        }
    }
}
