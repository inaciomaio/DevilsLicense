using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InacioDebugTest : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        Debug.DrawLine(transform.position, transform.position + transform.up);
    }
}