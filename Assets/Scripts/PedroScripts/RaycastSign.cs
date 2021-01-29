using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastSign : MonoBehaviour
{
    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up * 10f, 12f);
        Debug.DrawRay(transform.position, transform.up * 8f);
        
        if (hit && hit.collider.CompareTag("Sign"))
            {
                Manager.CanClickSign = true;
            }
            else
            {
                Manager.CanClickSign = false;
            }
    }
}    
