using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosswalkBehaviour : MonoBehaviour
{
    public bool PedDetected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ped"))
        {
            transform.gameObject.tag = "RedCrosswalk";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Ped"))
        {
            transform.gameObject.tag = "GreenCrosswalk";
        }
    }
}
