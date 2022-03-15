using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosswalkBehaviour : MonoBehaviour
{

    public int NumberOfPeds;

   // private void OnTriggerStay2D(Collider2D collision)
   // {
   //     //Debug.LogWarning(collision.gameObject.name);
   //     if (collision.gameObject.CompareTag("Ped"))
   //     {
   //         transform.gameObject.tag = "RedCrosswalk";
   //     }
   //     else transform.gameObject.tag = "GreenCrosswalk";
   // }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ped"))
        {
            NumberOfPeds++;
            transform.gameObject.tag = "RedCrosswalk";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ped"))
        {
            NumberOfPeds--;
            if(NumberOfPeds == 0)
            {
                transform.gameObject.tag = "GreenCrosswalk";
            }
            
        }
    }
}
