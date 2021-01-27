using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedDestinationManager : MonoBehaviour
{
    public List<Transform> Destinations;
    // Start is called before the first frame update
    void Start()
    {

        for(int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            Destinations.Add(child);

        }
    }
}
