using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUi : MonoBehaviour
{
    public GameObject _youLost;
    public GameObject _youWon;
    
    private TextMeshProUGUI _errorText;
    
    public Manager _manager;
    public GlobalManager _globalManager;
    public Characters livchar;

    void Awake()
    {
        _youLost = GameObject.Find("DefeatText");
        _youWon = GameObject.Find("VictoryText");

    }
    
    void Start()
    {
        if (GameObject.Find("Liv") != null)
        {
            livchar = GameObject.Find("Liv").GetComponent<Characters>();
        }
        _globalManager = GameObject.Find("GlobalManager").GetComponent<GlobalManager>(); // THIS IMPLIES THAT THE SCENE SHOULD BE RUN *AFTER* SCENE 0
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
        //if is Liv
        CheckIfMaxScoreLiv();
        _globalManager.SaveGame();
        SceneManager.LoadScene(_manager.currentSceneIndex);
    }

    public void ToMenuButton()
    {
        //if is Liv
        CheckIfMaxScoreLiv();
        _globalManager.SaveGame();
        SceneManager.LoadScene("Menu");
    }

    public void ExitButton()
    {
        //if is Liv
        CheckIfMaxScoreLiv();
        _globalManager.SaveGame();
        Application.Quit();
    }

    public void ResumeButton()
    {
        
    }

    void CheckIfMaxScoreLiv()
    {
        if (_manager.errorCount > _globalManager.maxLivScore)
        {
            _globalManager.maxLivScore = _manager.errorCount;
        }
    }
}
