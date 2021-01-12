using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOut : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip hoverbutton;
    public float volume = 0.5f;
    public bool hasPlayed = false;
    void Awake()
    {
        audioSource.clip = hoverbutton;
    }

    void OnMouseOver()
    {
        if (hasPlayed == false)
        {
            audioSource.Play();
            hasPlayed = true;
        }
    }

    void OnMouseExit()
    {
        hasPlayed = false;
        audioSource.PlayOneShot(hoverbutton, volume);
    }
}
