using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosswalkPed : MonoBehaviour
{
    public float Speed;
    public float Wait = 1f;
    void Awake()
    {
        StartCoroutine(WaitThis());
    }

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * Speed);
    }

    IEnumerator WaitThis()
    {
        yield return new WaitForSeconds(Wait);
        DestroyObj();
    }

    void DestroyObj()
    {
        Destroy(gameObject);
    }
}
