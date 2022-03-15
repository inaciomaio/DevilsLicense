using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTween : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip hoverbutton;
    public float volume = 0.5f;
    public bool hasPlayed = false;
    public Vector3 originalScale;

    private Vector3 currentScale;
    void Awake()
    {
        audioSource.clip = hoverbutton;
        originalScale = gameObject.transform.localScale;
    }
    void OnMouseOver()
    {
        LeanTween.scale(gameObject.GetComponent<RectTransform>(), originalScale*1.2f, 0.3f).setEase(LeanTweenType.easeSpring);
        if (hasPlayed == false)
        {
            audioSource.Play();
            hasPlayed = true;
        }
    }

    void OnMouseExit()
    {
        LeanTween.scale(gameObject.GetComponent<RectTransform>(), originalScale, 0.6f).setEase(LeanTweenType.easeSpring);
        hasPlayed = false;
        //audioSource.PlayOneShot(hoverbutton, volume);
    }
}
