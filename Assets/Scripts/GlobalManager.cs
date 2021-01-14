using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalManager : MonoBehaviour
{
    public float Volume;
    public float changeableVolume;
    public Slider volumeSlider;
    void Start()
    {
        Volume = AudioListener.volume;
    }

    void Update()
    {
        AudioListener.volume = volumeSlider.value;
    }
}
