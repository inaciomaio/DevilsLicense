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
        Application.Quit();
    }

    public void Tutorial()
    {
        SceneManager.LoadScene(3);
    }

    public void DebugRoom()
    {
        SceneManager.LoadScene(2);

    }

    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ToCredits()
    {
        SceneManager.LoadScene(3);
    }

    public void ToCharSelect()
    {
        SceneManager.LoadScene(2);
    }
}
