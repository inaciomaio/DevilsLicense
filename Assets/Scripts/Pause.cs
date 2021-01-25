using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Pause : MonoBehaviour
{
    public bool isAbleToPause;
    public bool IsPaused = false;
    private Manager _manager;

    private SpriteRenderer _pausedBg;
    public GameObject pauseUI;

    private float pbgr;
    private float pbgg;
    private float pbgb;
    public float pbga;
    void Awake()
    {
        _pausedBg = GameObject.Find("PausedBg").GetComponent<SpriteRenderer>();
        _manager = gameObject.GetComponent<Manager>();
        pauseUI = GameObject.Find("Pause");
        pauseUI.SetActive(false);

    }

    void Start()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Menu"))
        {
            isAbleToPause = false;
        }
        else
        {
            isAbleToPause = true;
        }
    }
    
    void Update()
    {
        if (isAbleToPause && _manager.gameEnded == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (IsPaused == false)
                {
                    PauseGame();
                }
                else
                {
                    ResumeGame(); 
                }
            }
        }
    }

    void ResumeGame()
    {
        pauseUI.SetActive(false);
        _manager.tempUi.SetActive(true);
        _manager.stars.SetActive(true);
        Time.timeScale = 1f;
        AudioListener.pause = false;
        IsPaused = false;
    }

    void PauseGame()
    {
        RandomizePauseColors();
        _pausedBg.color = new Color(pbgr, pbgg, pbgb, pbga);
        _manager.tempUi.SetActive(false);
        _manager.stars.SetActive(false);
        pauseUI.SetActive(true);
        AudioListener.pause = true;
        Time.timeScale = 0f;
        IsPaused = true;
    }

    void RandomizePauseColors()
    {
        pbgr = Random.Range(0f, .2f);
        pbgg = Random.Range(0f, .2f);
        pbgb = Random.Range(0f, .2f);
        pbga = 0.5f;
    }
    
    public void ResumeGameButton()
    {
        pauseUI.SetActive(false);
        _manager.tempUi.SetActive(true);
        _manager.stars.SetActive(true);
        Time.timeScale = 1f;
        AudioListener.pause = false;
        IsPaused = false;
    }
}
