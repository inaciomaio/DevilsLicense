using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public int Speed = 5;
    public float horizontal;
    public float vertical;
    void Start()
    {
        
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        transform.position = new Vector2(transform.position.x + horizontal * Speed * Time.deltaTime, transform.position.y + vertical * Speed * Time.deltaTime);
    }
}
