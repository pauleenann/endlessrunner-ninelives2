using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public string gameLevel;

    public void Play()
    {
        //displays game scene when play button is pressed
        Application.LoadLevel(gameLevel);
    } 

    public void Quit()
    {
        //quits game
        Application.Quit();
    }
}
