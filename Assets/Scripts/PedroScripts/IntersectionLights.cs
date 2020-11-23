using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class IntersectionLights : MonoBehaviour
{
    /*
    * 1 is green
    * 0 is red
    *
    * !!! Color values should be changed in inspector to match color !!!
    * Change this component's array size in unity inspector of Intersection1
    * Add new Vlight or Hlight in component's array
    * Test for timing
    */

    public int hcolor;
    public int vcolor;
    public float tt;

    public Sprite greenLightSp;
    public Sprite redLightSp;

    public SpriteRenderer[] horizontalLights;
    public SpriteRenderer[] verticalLights;

    void Start()
    {
        greenLightSp = Resources.Load<Sprite>("Sprites/greenlight");
        redLightSp = Resources.Load<Sprite>("Sprites/redlight");
    }
    
    void Update()
    {
        tt = Manager.T;
        if (Manager.T > 10)
        {
            StartCoroutine("ColorChange");
        }
    }

    IEnumerator ColorChange()
    {
        for (int i = 0; i < horizontalLights.Length; i++)
        {
            if (hcolor == 0)
            {
                horizontalLights[i].sprite = greenLightSp;
            }
            else if (hcolor == 1)
            {
                horizontalLights[i].sprite = redLightSp;
            }
        }

        for (int i = 0; i < verticalLights.Length; i++)
        {
            if (vcolor == 0)
            {
                verticalLights[i].sprite = greenLightSp;
            }
            else if (vcolor == 1)
            {
                verticalLights[i].sprite = redLightSp;
            }
        }

        if (hcolor == 0)
        {
            hcolor = 1;
        }
        else
        {
            hcolor = 0;
        }

        if (vcolor == 0)
        {
            vcolor = 1;
        }
        else
        {
            vcolor = 0;
        }
        
        yield return Manager.T = 0;
    }
    
    public void ChangeLightsCall()
    {
        for (int i = 0; i < horizontalLights.Length; i++)
        {
            if (hcolor == 0)
            {
                horizontalLights[i].sprite = greenLightSp;
            }
            else if (hcolor == 1)
            {
                horizontalLights[i].sprite = redLightSp;
            }
        }

        for (int i = 0; i < verticalLights.Length; i++)
        {
            if (vcolor == 0)
            {
                verticalLights[i].sprite = greenLightSp;
            }
            else if (vcolor == 1)
            {
                verticalLights[i].sprite = redLightSp;
            }
        }

        if (hcolor == 0)
        {
            hcolor = 1;
        }
        else
        {
            hcolor = 0;
        }

        if (vcolor == 0)
        {
            vcolor = 1;
        }
        else
        {
            vcolor = 0;
        }
        
        Manager.T = 0;
    }
}
