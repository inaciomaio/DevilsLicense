using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    private bool isAbleToPause;
    public bool IsPaused = false;
    
    void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Menu"))
        {
            isAbleToPause = false;
        }
        else
        {
            isAbleToPause = true;
        }

        if (isAbleToPause)
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
        Time.timeScale = 1f;
        IsPaused = false;
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        IsPaused = true;
    }
}
