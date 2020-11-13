using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class IntersectionLights : MonoBehaviour
{
    /* 0 is green
       1 is red */
    
    public int color;
    public float T;

    public SpriteRenderer[] horizontalLights;
    public SpriteRenderer[] verticalLights;

    void Start()
    { 
        
    }

    void Update()
    {
        T += Time.deltaTime;

        if (T > 10)
        {
            for (int i = 0; i < horizontalLights.Length; i++)
            {
                horizontalLights[i].color = UnityEngine.Color.green;
            }

            for (int i = 0; i < verticalLights.Length; i++)
            {
                verticalLights[i].color = UnityEngine.Color.red;
            }
        }
        else if (T > 20)
        {
            for (int i = 0; i < horizontalLights.Length; i++)
            {
                horizontalLights[i].color = UnityEngine.Color.red;
            }
            
            for (int i = 0; i < verticalLights.Length; i++)
            {
                verticalLights[i].color = UnityEngine.Color.red;
            }

            T = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Car"))
        {
            StartCoroutine("CrossingIntersection");
            //Time.timeScale = 0.5;
            
            //Debug.Log("Car entering" + " " + gameObject.name);
        }
    }

    private IEnumerator CrossingIntersection()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("Car entering" + " " + gameObject.name);
        yield return new WaitForSeconds(1);
    }
}
