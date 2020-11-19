using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class IntersectionLights : MonoBehaviour
{
    /* * 1 is green
       * 0 is red
       * 
       * !!! Color values should be changed in inspector to match color !!!
       * Set Array size in inspector
       */

    public int hcolor;
    public int vcolor;
    public float T;

    public SpriteRenderer[] horizontalLights;
    public SpriteRenderer[] verticalLights;

    void Update()
    {
        T += Time.deltaTime;

        if (T > 10)
        {
            for (int i = 0; i < horizontalLights.Length; i++)
            {
                if (hcolor == 0)
                {
                    horizontalLights[i].color = UnityEngine.Color.green;
                }
                else if (hcolor == 1)
                {
                    horizontalLights[i].color = UnityEngine.Color.red;
                }
            }

            for (int i = 0; i < verticalLights.Length; i++)
            {
                if (vcolor == 0)
                {
                    verticalLights[i].color = UnityEngine.Color.green;
                }
                else if (vcolor == 1)
                {
                    verticalLights[i].color = UnityEngine.Color.red;
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

                T = 0;
        }
    }
}
