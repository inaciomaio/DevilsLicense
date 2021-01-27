using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableRoadBakingColliders : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            Destroy(child.GetComponent<PolygonCollider2D>());
        }
    }
}
