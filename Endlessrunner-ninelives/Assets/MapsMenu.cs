using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MapsMenu : MonoBehaviour
{
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI fishText;
    public int totalCoins;
    public int totalFish;
    public int forestPrice = 100000;
    public int houseFencePrice = 200000;
    public int nightMapPrice = 300000;
    public string defaultLevel;
    public string forestLevel;
    public string houseFencesLevel;
    public string nightLevel;
    public string mainMenuLevel;
    public string mapLevel;
    public GameObject insufficientCoins;
    
    void Start()
    {
        if (PlayerPrefs.HasKey("HighCoin"))
        {
            totalCoins = PlayerPrefs.GetInt("HighCoin");
        }

        if (PlayerPrefs.HasKey("HighFish"))
        {
            totalFish = PlayerPrefs.GetInt("HighFish");
        }

        coinsText.text = "" + totalCoins;
        fishText.text = "" + totalFish;
    }

    public void BackToMap()
    {
        Application.LoadLevel(mapLevel);
    }

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
        if(totalCoins >= nightMapPrice)
        {
            Application.LoadLevel(nightLevel);
        }
        
        
    }
}
