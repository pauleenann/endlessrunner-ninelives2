using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public string catLevel;
    public string mapLevel;
    public string aboutUsLevel;


  
    public void Play()
    {
        //displays game scene when play button is pressed
        Application.LoadLevel(mapLevel);
    } 

    public void Cat()
    {
        Application.LoadLevel(catLevel);
    }

    public void AboutUs()
    {
        Application.LoadLevel(aboutUsLevel);
    }

    public void Quit()
    {
        //quits game
        Application.Quit();
    }
}
