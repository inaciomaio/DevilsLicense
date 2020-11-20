using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    public GameObject _manager;
    void Awake()
    {
        if (GameObject.Find("Manager") == null)
        {
            Instantiate(_manager);
            GameObject.Find("Manager(Clone)").name = "Manager";
        }
    }

    void Update()
    {

    }
}
