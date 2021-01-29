using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButtons : MonoBehaviour
{
    public GameObject Livcard;
    public GameObject Nikocard;

    private GameObject backbttn;

    private GlobalManager _globalManager;
    
    // if (GM.errors == 0 2 3 etc)
    // { IGNORE THIS
    //     Livcard.score == etc
    // }

    void Awake()
    {

        backbttn = GameObject.Find("BackButton"); 
        
        Livcard = GameObject.Find("LivCard");
        Nikocard = GameObject.Find("NikoCard");

        _globalManager = GameObject.Find("GlobalManager").GetComponent<GlobalManager>();
        
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

    public void StartNiko()
    {
        _globalManager.nikopicked = true;
        SceneManager.LoadScene(1);
    }

    public void StartLiv()
    {
        _globalManager.livpicked = true;
        SceneManager.LoadScene(1);
    }
}
