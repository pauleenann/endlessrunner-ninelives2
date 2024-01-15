using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeMenu : MonoBehaviour
{
    public string mainMenuLevel;

    public GameObject resumeMenu;

    public void Restart()
    {
        Time.timeScale = 1f;
        resumeMenu.SetActive(false);
        FindObjectOfType<GameManager>().Reset();
    }

    public void QuitToMain()
    {
        Time.timeScale = 1f;
        Application.LoadLevel(mainMenuLevel);
    }

    public void Pause()
    {
        //time wont move at all, everything stops
        Time.timeScale = 0f;
        resumeMenu.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        resumeMenu.SetActive(false);
        FindObjectOfType<GameManager>().Resume();
    }
}
