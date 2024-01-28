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
        //this saves the maps that you purchased to playerprefs
        //kaya kahit iexit mo yung game, then plinay mo ulit, ung maps na binili mo ay malalaro mo pa rin
        nightMapPrice = PlayerPrefs.GetInt("NightMapPrice", 300000);  // Use your default value
        forestMapPrice = PlayerPrefs.GetInt("ForestMapPrice", 100000);  // Use your default value

        //uncomment this kung gusto mo mawala sa playerprefs yung maps na binili mo
        //therefore, kailagan mo ulit siyang bilhin
        //uncomment mo yung dalawa sa taas kung gusto mo sila bilhin ulit HAHA
        //PlayerPrefs.DeleteKey("ForestMapPrice");
        //PlayerPrefs.DeleteKey("NightMapPrice");
        //PlayerPrefs.SetInt("HighCoin", 500000);
        //PlayerPrefs.SetInt("HighFish", 500);


        if (PlayerPrefs.HasKey("HighCoin"))
        {
            totalCoins = PlayerPrefs.GetInt("HighCoin");
        }

        if (PlayerPrefs.HasKey("HighFish"))
        {
            totalFish = PlayerPrefs.GetInt("HighFish");
        }

        if(nightMapPrice == 0)
        {
            nightCoin.SetActive(false);
            nightPrice.SetActive(false);
            nightPlay.SetActive(true);
        }

        if (forestMapPrice == 0)
        {
            forestCoin.SetActive(false);
            forestPrice.SetActive(false);
            forestPlay.SetActive(true);
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
        if (nightMapPrice != 0)
        {
            buyNight.SetActive(true);
        }
        else
        {
            Application.LoadLevel(nightLevel);
        }

        //Debug.Log(totalCoins);
        //Debug.Log(nightMapPrice);
        //if(nightMapPrice != 0){
        //    buyNight.SetActive(true);
        //}
        //else if (nightMapPrice == 0)
        //{
        //    Application.LoadLevel(nightLevel);
        //}
        //else if(totalCoins >= nightMapPrice)
        //{
        //    mapUnlocked.SetActive(true);
        //    nightCoin.SetActive(false);
        //    nightPrice.SetActive(false);
        //    nightPlay.SetActive(true);
        //    totalCoins -= nightMapPrice;
        //    nightMapPrice = 0;
        //    coinsText.text = "" + totalCoins;
        //    //LoadLevel(nightLevel);
        //}
        //else
        //{
         
        //    insufficientCoins.SetActive(true);
        //}
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
            PlayerPrefs.SetInt("ForestMapPrice", forestMapPrice);
            PlayerPrefs.SetInt("HighCoin", totalCoins);
            PlayerPrefs.Save();
        }

        else
        {

            insufficientCoins.SetActive(true);
        }
    }

    public void BuyMapNight()
    {
        if (totalCoins >= nightMapPrice)
        {
            mapUnlocked.SetActive(true);
            nightCoin.SetActive(false);
            nightPrice.SetActive(false);
            nightPlay.SetActive(true);
            totalCoins -= nightMapPrice;
            nightMapPrice = 0;
            coinsText.text = "" + totalCoins;
            //LoadLevel(nightLevel);
            PlayerPrefs.SetInt("NightMapPrice", nightMapPrice);
            PlayerPrefs.SetInt("HighCoin", totalCoins);
            PlayerPrefs.Save();
        }

        else
        {

            insufficientCoins.SetActive(true);
        }
    }
    
}
