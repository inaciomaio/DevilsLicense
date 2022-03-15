using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class Options : MonoBehaviour
{
    public GameObject Logo;
    public GameObject Start;
    public GameObject Exit;
    public GameObject optionsObj;
    public GameObject fsCheck;
    public GameObject volumeSlider;

    public TMPro.TMP_Dropdown resolutionDropdown;

    public Resolution[] resolutions;

    public bool toggleActive = true;
    public bool hasClicked;
    void Awake()
    {
        Logo = GameObject.Find("logo");
        Start = GameObject.Find("Start");
        Exit = GameObject.Find("Exit");
        volumeSlider = GameObject.Find("VolumeSlider");
        optionsObj = GameObject.Find("Optionsimage");
        volumeSlider.SetActive(false);
        optionsObj.SetActive(false);

        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        int currentResolutionIndex = 0;

        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width+ "x" + resolutions[i].height + " " + resolutions[i].refreshRate + " " + "Hz";
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height && resolutions[i].refreshRate == Screen.currentResolution.refreshRate)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
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
        optionsObj.SetActive(true);
        volumeSlider.SetActive(true);
        LeanTween.alpha(optionsObj, 1f, 0.1f);
        LeanTween.alpha(volumeSlider, 1f, 0.1f);
        yield return new WaitForSecondsRealtime(0.1f);
        toggleActive = false;
        Logo.SetActive(toggleActive);
        Start.SetActive(toggleActive);
        Exit.SetActive(toggleActive);
        hasClicked = false;
        yield break;
    }
    IEnumerator fadeIn()
    {
        hasClicked = true;
        LeanTween.alpha(optionsObj, 0f, 0.1f);
        LeanTween.alpha(volumeSlider, 0, 0.1f);
        yield return new WaitForSecondsRealtime(0.1f);
        optionsObj.SetActive(false);
        volumeSlider.SetActive(false);
        LeanTween.alpha(Logo, 1, 0.5f);
        LeanTween.alpha(Start.GetComponent<RectTransform>(), 1, 0.5f);
        LeanTween.alpha(Exit.GetComponent<RectTransform>(), 1, 0.5f);
        Logo.SetActive(toggleActive);
        Start.SetActive(toggleActive);
        Exit.SetActive(toggleActive);
        hasClicked = false;
        yield break;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetFullscreen(bool isFs)
    {
        Screen.fullScreen = isFs;
    }
}
