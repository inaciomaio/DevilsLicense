using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButtons : MonoBehaviour
{
    public GameObject Livcard;
    public GameObject Nikocard;

    private GameObject backbttn;
    /*
    if (GM.errors == 0 2 3 etc)
    {
        Livcard.score == etc
    }*/

    void Awake()
    {
        backbttn = GameObject.Find("BackButton"); 
        
        Livcard = GameObject.Find("LivCard");
        Nikocard = GameObject.Find("NikoCard");
        
        Livcard.SetActive(false);
        Nikocard.SetActive(false);
    }

    public void ClickLiv()
    {
        backbttn.SetActive(false);
        Livcard.SetActive(true);
    }

    public void ClickNiko()
    {
        backbttn.SetActive(false);
        Nikocard.SetActive(true);
    }

    public void Back()
    {
        backbttn.SetActive(true);
        Livcard.SetActive(false);
        Nikocard.SetActive(false);
    }
}
