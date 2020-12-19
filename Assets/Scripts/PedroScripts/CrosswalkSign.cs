using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosswalkSign : MonoBehaviour
{
    public GameObject spawnCw;
    public GameObject cwPrefab; //For test, it will be a sprite !! REPLACE FOR PREFAB OBJECT !!

    public bool canSpawn = true;
    void Start()
    {
        cwPrefab = Resources.Load<GameObject>("Prefabs/passadeira");
    }

    public void OnPointerEnter()
    {
        Debug.Log("TestPointer");
    }

    public void ClickSpawn()
    {
        if (canSpawn)
        {
            canSpawn = false;
            Instantiate(cwPrefab, spawnCw.transform);
        }
    }
}
