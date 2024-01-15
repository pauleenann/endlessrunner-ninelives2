using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapsMenu : MonoBehaviour
{
    public string defaultLevel;
    public string forestLevel;
    public string houseFencesLevel;
    public string nightLevel;
    public string mainMenuLevel;

   public void Back()
    {
        Application.LoadLevel(mainMenuLevel);
    }

   public void Default()
    {
        Application.LoadLevel(defaultLevel);
    }

    public void Forest()
    {
        Application.LoadLevel(forestLevel);
    }

    public void HouseFences()
    {
        Application.LoadLevel(houseFencesLevel);
    }

    public void Night()
    {
        Application.LoadLevel(nightLevel);
    }
}
