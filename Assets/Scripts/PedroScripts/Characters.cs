using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters : MonoBehaviour
{
    private Animator _animator;
    private Manager _manager;
    private GlobalManager _globalManager;
    private int errors;
    public float timeSinceError;
    private bool noErrors;
    public bool isLiv;
    public bool isNikolai;
    
    void Start()
    {
        _globalManager = GameObject.Find("GlobalManager").GetComponent<GlobalManager>();
        _manager = GameObject.Find("Manager").GetComponent<Manager>();
        _animator = gameObject.GetComponent<Animator>();
        
        if (_globalManager.livpicked && isNikolai)
        {
            gameObject.SetActive(false);
        }
        else if (_globalManager.nikopicked && isLiv)
        {
            gameObject.SetActive(false);
        }
        
        timeSinceError = 0;
    }

    void Update()
    {
        timeSinceError += Time.deltaTime;
        
        errors = _manager.errorCount;
        _animator.SetInteger("Errors",errors);
        _animator.SetBool("NoErrors",noErrors);

        if (isLiv)
        {
            if (timeSinceError > 15)
            {
                noErrors = true;
            }
        }
        else if (isNikolai)
        {
            if (timeSinceError > 25)
            {
                noErrors = true;
            }
        }
        else
        {
            if (timeSinceError > 25)
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
}
