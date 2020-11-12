using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Application = UnityEngine.Application;

public class MenuButton : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        if (Application.isEditor)
        {
            Debug.Log("Quit");
        }
        else
        {
            {
                Application.Quit();
            }
        }
    }

    public void DebugRoom()
    {
        SceneManager.LoadScene(2);
    }
}
