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
    public int forestMapPrice;
    public int nightMapPrice;
    public string forestLevel;
    public string defaultLevel;
    public string nightLevel;
    public string mainMenuLevel;
    public string mapLevel;
    public GameObject insufficientCoins;
    public GameObject mapUnlocked;
    public GameObject nightCoin;
    public GameObject nightPrice;
    public GameObject nightPlay;
    public GameObject buyNight;
    public GameObject forestCoin;
    public GameObject forestPrice;
    public GameObject forestPlay;
    public GameObject buyForest;
    
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
        if(forestMapPrice != 0)
        {
            buyForest.SetActive(true);  
        }
        else
        {
            Application.LoadLevel(forestLevel);
        }
         
        //if (totalCoins >= nightMapPrice)
        //{
        //    Application.LoadLevel(forestLevel);
        //}
        //else
        //{
        //    insufficientCoins.SetActive(true);
        //}
    }

    public void Night()
    {
        Debug.Log(totalCoins);
        Debug.Log(nightMapPrice);
        if(nightMapPrice != 0){
            buyNight.SetActive(true);
        }
        else if (nightMapPrice == 0)
        {
            Application.LoadLevel(nightLevel);
        }
        else if(totalCoins >= nightMapPrice)
        {
            mapUnlocked.SetActive(true);
            nightCoin.SetActive(false);
            nightPrice.SetActive(false);
            nightPlay.SetActive(true);
            totalCoins -= nightMapPrice;
            nightMapPrice = 0;
            coinsText.text = "" + totalCoins;
            //LoadLevel(nightLevel);
        }
        else
        {
         
            insufficientCoins.SetActive(true);
        }
    }

    public void BuyMap()
    {
        if (totalCoins >= forestMapPrice)
        {
            mapUnlocked.SetActive(true);
            forestCoin.SetActive(false);
            forestPrice.SetActive(false);
            forestPlay.SetActive(true);
            totalCoins -= forestMapPrice;
            forestMapPrice = 0;
            coinsText.text = "" + totalCoins;
            //LoadLevel(nightLevel);
        }
        else
        {

            insufficientCoins.SetActive(true);
        }
    }
    
}
