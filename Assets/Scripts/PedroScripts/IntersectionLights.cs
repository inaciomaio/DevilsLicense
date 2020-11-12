using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntersectionLights : MonoBehaviour
{
    /* 0 is green
       1 is red */
    
    public int Color;
    public float T;

    public SpriteRenderer[] HorizontalLights;
    public SpriteRenderer[] VerticalLights;
    
    void Start()
    {
        
    }

    void Update()
    {
        T += Time.deltaTime;

        if (T > 10)
        {
            for (int i = 0; i < HorizontalLights.Length; i++)
            {
                HorizontalLights[i].color = UnityEngine.Color.green;
            }

            for (int i = 0; i < VerticalLights.Length; i++)
            {
                VerticalLights[i].color = UnityEngine.Color.red;
            }
        }
    }
}
