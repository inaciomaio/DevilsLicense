using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CarAI))]
[RequireComponent(typeof(AudioClip))]
public class CarSound : MonoBehaviour
{
    private CarAI car;
    public AudioClip IdleClip;
    public float PitchMin = 1.45f;
    public float PitchMax = 1.85f;
    public float DopplerLevel = 1;
    public bool UseDoppler = true;

    private AudioSource source;
    private bool startedSound;


    void Start()
    {
        car = GetComponent<CarAI>();
        StartSound();
    }



    private void StartSound()
    {
        startedSound = true;
        SetupAudioSource(IdleClip);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(startedSound)
        {
            if(!car.CanDrive | car.TargetSpeed == 0)
            {
                source.pitch = 1;
            }
            else if(car.TargetSpeed > 5)
            {
                source.pitch = PitchMax;
            }
            else if(car.TargetSpeed == 5f)
            {
                source.pitch = PitchMin;
            }
        

        }

    }

    private AudioSource SetupAudioSource(AudioClip clip)
    {
        source = gameObject.AddComponent<AudioSource>();
        source.clip = clip;
        source.volume = 0.06f;
        source.loop = true;

        source.time = Random.Range(0f, clip.length);
        source.Play();
        source.minDistance = 5;
        source.dopplerLevel = 0;
        return source;
    }

}
