using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{
    public bool isLiv; //CHANGE IN INSPECTOR
    public bool isNikolai; //CHANGE IN INSPECTOR
    public int score;
    private GlobalManager _globalManager;
    public GameObject _checkmark1;
    public GameObject _checkmark2;
    public GameObject _checkmark3;

    void Awake()
    {
        _globalManager = GameObject.Find("GlobalManager").GetComponent<GlobalManager>();
        _checkmark1.SetActive(false);
        _checkmark2.SetActive(false);
        _checkmark3.SetActive(false);
    }
    void Start()
    {
        if (isLiv) //if this is in Liv component
        {
            score = _globalManager.maxLivScore;
            switch (score)
            {
                case 0:
                    break;
                case 1:
                    _checkmark1.SetActive(true);
                    break;
                case 2:
                    _checkmark1.SetActive(true);
                    _checkmark2.SetActive(true);
                    break;
                case 3:
                    _checkmark1.SetActive(true);
                    _checkmark2.SetActive(true);
                    _checkmark3.SetActive(true);
                    break;
            }
        }
        else if (isNikolai)
        {
            score = _globalManager.maxNikoScore;
            switch (score)
            {
                case 0:
                    break;
                case 1:
                    _checkmark1.SetActive(true);
                    break;
                case 2:
                    _checkmark1.SetActive(true);
                    _checkmark2.SetActive(true);
                    break;
                case 3:
                    _checkmark1.SetActive(true);
                    _checkmark2.SetActive(true);
                    _checkmark3.SetActive(true);
                    break;
            }
        }
    }
}
