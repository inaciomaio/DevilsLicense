using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlobalManager : MonoBehaviour
{
    public float Volume;
    public float changeableVolume;
    public Slider volumeSlider;

    private static GameObject globalManager;

    void Awake()
    {
        if (globalManager)
        {
            Destroy(gameObject);
        }
        else
        {
            globalManager = gameObject;
        }
        
        
    }

    void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0))
        {
            Volume = AudioListener.volume; //Need to create individual audio manager for different levels.
            AudioListener.volume = volumeSlider.value; //This needs to go to a new audio manager.
        }
    }
}
