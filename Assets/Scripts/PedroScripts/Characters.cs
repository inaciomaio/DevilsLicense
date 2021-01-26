using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters : MonoBehaviour
{
    private Animator _animator;
    private Manager _manager;
    private int errors;
    public float timeSinceError;
    private bool noErrors;

    void Start()
    {
        _manager = GameObject.Find("Manager").GetComponent<Manager>();
        _animator = gameObject.GetComponent<Animator>();
        timeSinceError = 0;
    }

    void Update()
    {
        timeSinceError += Time.deltaTime;
        
        errors = _manager.errorCount;
        _animator.SetInteger("Errors",errors);
        _animator.SetBool("NoErrors",noErrors);

        if (timeSinceError > 20)
        {
            noErrors = true;
            timeSinceError = 0;
        }

        if (timeSinceError > 10)
        {
            noErrors = false;
        }
    }
}
