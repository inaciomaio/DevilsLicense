using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    private Pause _managerpause;
    private Manager _manager;
    public TMPro.TMP_Dropdown resolutionDropdown;
    public Resolution[] resolutions;
    
    void Start()
    {
        _managerpause = GameObject.Find("Manager").GetComponent<Pause>();

        _manager = GameObject.Find("Manager").GetComponent<Manager>();
        
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
    
    public void ResumeButton()
    {
        _managerpause.ResumeGameButton();
        _manager._carAi.CanDrive = true;
    }

    public void MenuButton()
    {
        Time.timeScale = 1f; // Timescale 0 in menu will make tweens not work. Audiolistener needs to be unpaused too so it will work in menu.
        AudioListener.pause = false;
        SceneManager.LoadScene(0);
    }

    public void ExitButton()
    {
        Application.Quit();
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

    public void Tryagaine()
    {
        AudioListener.pause = false;
        SceneManager.LoadScene(_manager.currentSceneIndex);
    }
}
