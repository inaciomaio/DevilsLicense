using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    Transform player;

    void Awake()
    {
        player = GameObject.Find("Player").transform;   
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
    }
}
