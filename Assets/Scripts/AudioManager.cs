using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{
    public GameObject instructions;
    public Manager manager;

    void Awake()
    {
        if (GameObject.Find("Manager") != null)
        {
            manager = GameObject.Find("Manager").GetComponent<Manager>();
        }
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    public void Play()
    {
        instructions.SetActive(false);
        manager.pause.isAbleToPause = true;
        Time.timeScale = 1;
    }
}
