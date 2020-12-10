using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameOverUI : MonoBehaviour
{
    private GameObject _youLost;
    private GameObject _youWon;

    private TextMeshProUGUI _errorText;
    
    private Manager _manager;
    void Awake()
    {
        _youLost = GameObject.Find("YouLostText");
        _youWon = GameObject.Find("YouWonText");
        _errorText = GameObject.Find("ErrorsText").GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        _manager = GameObject.Find("Manager").GetComponent<Manager>();
        _youLost.SetActive(false);
        _youWon.SetActive(false);
        
        if (_manager.errorCount >= 3)
        {
            _youWon.SetActive(true);
        }
        else
        {
            _youLost.SetActive(true);
        }

        _errorText.text = "Errors:" + " " + _manager.errorCount;
    }
    
    public void RetryButton()
    {
        _manager.errorCount = 0;
        SceneManager.LoadScene(_manager.currentSceneIndex);
    }

    public void ToMenuButton()
    {
        _manager.errorCount = 0;
        SceneManager.LoadScene("Menu");
    }
}
