using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class Options : MonoBehaviour
{
    public GameObject Logo;
    public GameObject Start;
    public GameObject Exit;
    public GameObject optionsObj;
    public GameObject fsCheck;

    public bool toggleActive = true;
    public bool hasClicked;

    public bool isFs;
    void Awake()
    {
        Logo = GameObject.Find("logo");
        Start = GameObject.Find("Start");
        Exit = GameObject.Find("Exit");
        optionsObj = GameObject.Find("Optionsimage");
        optionsObj.SetActive(false);
        fsCheck.SetActive(Screen.fullScreen);

        isFs = Screen.fullScreen;
}

    public void ToggleOptionsMenu()
    {
        if (toggleActive && hasClicked == false)
        {
            StartCoroutine(fadeOut());
            
        }
        else
        {
            toggleActive = true;
            StartCoroutine(fadeIn());
        }
    }

    IEnumerator fadeOut()
    {
        hasClicked = true;
        LeanTween.alpha(Start.GetComponent<RectTransform>(), 0f, 0.5f);
        LeanTween.alpha(Exit.GetComponent<RectTransform>(), 0f, 0.5f);
        LeanTween.alpha(Logo, 0f, 0.5f);
        yield return new WaitForSecondsRealtime(1f);
        optionsObj.SetActive(true);
        LeanTween.alpha(optionsObj, 1f, 0.1f);
        yield return new WaitForSecondsRealtime(0.1f);
        Logo.SetActive(toggleActive);
        Start.SetActive(toggleActive);
        Exit.SetActive(toggleActive);
        toggleActive = false;
        hasClicked = false;
        yield break;
    }
    IEnumerator fadeIn()
    {
        hasClicked = true;
        LeanTween.alpha(optionsObj, 0f, 0.1f);
        yield return new WaitForSecondsRealtime(0.1f);
        optionsObj.SetActive(true);
        LeanTween.alpha(Logo, 1, 0.5f);
        LeanTween.alpha(Start.GetComponent<RectTransform>(), 1, 0.5f);
        LeanTween.alpha(Exit.GetComponent<RectTransform>(), 1, 0.5f);
        yield return new WaitForSecondsRealtime(1f);
        Logo.SetActive(toggleActive);
        Start.SetActive(toggleActive);
        Exit.SetActive(toggleActive);
        hasClicked = false;
        yield break;
    }

    public void SetFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
        if (Screen.fullScreen)
        {
            Debug.Log("Is Fs");
        }
        else
        {
            Debug.Log("Isnt Fs");
        }
    }
}
