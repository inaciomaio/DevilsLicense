using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUi : MonoBehaviour
{
    private GameObject _youLost;
    private GameObject _youWon;
    
    private TextMeshProUGUI _errorText;
    
    private Manager _manager;
    void Awake()
    {
        _youLost = GameObject.Find("DefeatText");
        _youWon = GameObject.Find("VictoryText");

    }
    
    void Start()
    {
        _manager = GameObject.Find("Manager").GetComponent<Manager>();
        
        _youWon.SetActive(false);
        _youLost.SetActive(false);

        if (_manager.errorCount >= 3)
        {
            _youWon.SetActive(true);
        }
        else
        {
            _youLost.SetActive(true);
        }
    }
    
    //After game over, save game (Manager)
    
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

    public void ExitButton()
    {
        Application.Quit();
    }

    public void ResumeButton()
    {
        
    }
}
