using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SignTween : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer signSr;
    private Manager _manager;
    public Color normalColor;
    public Color highlightColor;

    private void Awake()
    {
        normalColor = signSr.color;
        highlightColor = new Color(255/255, 178/255, 155/255);
    }
   
    private void Start()
    {
        _manager = GameObject.Find("Manager").GetComponent<Manager>();
    }

    void OnMouseOver()
    {

    }
    void OnMouseExit()
    {

    }
    public void HighlightColor()
    {
        if (_manager.promptIsPossible)
        {
            signSr.color = highlightColor;

        }
    }
    public void NormalColor()
    {
        signSr.color = normalColor;
    }
}