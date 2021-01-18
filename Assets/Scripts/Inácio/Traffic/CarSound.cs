using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CarAI))]
public class CarSound : MonoBehaviour
{
    
    void Start()
    {
        
    }

    public enum EngineAudioOptions
    {
        Simple,
        FourChannel
    }

    public EngineAudioOptions EngineSoundStyle = EngineAudioOptions.FourChannel;
    public AudioClip LowAccelClip;
    public AudioClip LowDecelClip;
    public AudioClip HighAccelClip;
    public AudioClip HighDecelClip;
    public float PitchMultiplier = 1f;
    public float LowPitchMin = 1f;
    public float LowPitchMax = 6f;
    public float HighPitchMultiplier = .25f;
    public float MaxRollOffDistance = 500;
    public float DopplerLevel = 1;
    public bool UseDoppler = true;

    private AudioSource lowAccel;
    private AudioSource lowDecel;
    private AudioSource highAccel;
    private AudioSource highDecel;
    private bool startedSound;
    private CarAI CarAI;

    private void StartSound()
    {
        //highAccel = SetUpEngineAudioSource(HighAccelClip);
    }

    // Update is called once per frame
    void Update()
    {
        //float camDist = (Camera.main.transform.position - transform.position).sqrMagnitude;
    }

}
