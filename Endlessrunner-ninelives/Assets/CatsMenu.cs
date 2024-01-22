using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CatsMenu : MonoBehaviour
{
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI fishText;
    public TextMeshProUGUI adoptBengal;
    public TextMeshProUGUI adoptNorwegian;
    public TextMeshProUGUI adoptShorthair;
    public TextMeshProUGUI adoptDefault;

    public int totalCoins;
    public int totalFish;
    public string mainMenuLevel;
    public int bengalPrice;
    public int norwegianPrice;
    public int shorthairPrice;
    public GameObject insufficientCoins;
    public GameObject mapUnlocked;
    public string mapLevel;

    public GameObject[] seletCat;
    public GameObject[] catsDescription;

    public int selectedPlayer;

    public TextMeshProUGUI[] adoptText;
    public int[] catPrices = { 0, 0, 0, 0 }; // Initialize with default values



    void Start()
    {
        bengalPrice = PlayerPrefs.GetInt("BengalPrice", 100);
        norwegianPrice = PlayerPrefs.GetInt("NorwegianPrice", 150);
        shorthairPrice = PlayerPrefs.GetInt("ShorthairPrice", 200);
        selectedPlayer = PlayerPrefs.GetInt("SelectedPlayer", 0);

        //PlayerPrefs.DeleteKey("SelectedPlayer");
        //PlayerPrefs.DeleteKey("BengalPrice");
        //PlayerPrefs.DeleteKey("NorwegianPrice");
        //PlayerPrefs.DeleteKey("ShorthairPrice");

        catPrices[1] = bengalPrice;
        catPrices[2] = norwegianPrice;
        catPrices[3] = shorthairPrice;

        coinsText.text = "" + totalCoins;
        fishText.text = "" + totalFish;
    }

    void Update()
    {
        for (int i = 0; i < 4; i++)
        {
            if (i != selectedPlayer && catPrices[i] == 0)
            {
                adoptText[i].text = "Use";
            }
            else if(i == selectedPlayer && catPrices[i] == 0)
            {
                Debug.Log(i);
                adoptText[i].text = "In Use";
            }
        }

        SaveCatPrices();
    }

    void SaveCatPrices()
    {
        string catPricesString = string.Join(",", catPrices);
        PlayerPrefs.SetString("CatPrices", catPricesString);
        PlayerPrefs.Save();
    }

    public void Back()
    {
        Application.LoadLevel(mainMenuLevel);
    }

    public void bengalCat()
    {
        if (bengalPrice != 0)
        {
            catsDescription[1].SetActive(true);
        }
        else
        {
            seletCat[1].SetActive(true);
        }
        
    }

    public void bengalDesc()
    {
        if (totalFish >= bengalPrice)
        {
            mapUnlocked.SetActive(true);
            totalFish -= bengalPrice;
            bengalPrice = 0;
            fishText.text = "" + totalFish;
            adoptBengal.text = "Use";
            catPrices[1] = bengalPrice;
            PlayerPrefs.SetInt("BengalPrice", bengalPrice);
            PlayerPrefs.SetInt("HighFish", totalFish);
            PlayerPrefs.Save();
        }
        else
        {

            insufficientCoins.SetActive(true);
        }
    }

    public void NorwegianCat()
    {
        if (norwegianPrice != 0)
        {
            catsDescription[2].SetActive(true);
        }
        else
        {
            seletCat[2].SetActive(true);
        }

    }

    public void NorwegianDesc()
    {
        if (totalFish >= norwegianPrice)
        {
            mapUnlocked.SetActive(true);
            totalFish -= norwegianPrice;
            norwegianPrice = 0;
            catPrices[2] = norwegianPrice;
            fishText.text = "" + totalFish;
            adoptNorwegian.text = "Use";
            PlayerPrefs.SetInt("NorwegianPrice", norwegianPrice);
            PlayerPrefs.SetInt("HighFish", totalFish);
            PlayerPrefs.Save();
        }
        else
        {

            insufficientCoins.SetActive(true);
        }
    }

    public void ShorthairCat()
    {
        if (shorthairPrice != 0)
        {
            catsDescription[3].SetActive(true);
        }
        else
        {
            seletCat[3].SetActive(true);
        }

    }

    public void ShorthairDesc()
    {
        if (totalFish >= shorthairPrice)
        {
            mapUnlocked.SetActive(true);
            totalFish -= shorthairPrice;
            shorthairPrice = 0;
            catPrices[3] = shorthairPrice;
            fishText.text = "" + totalFish;
            adoptShorthair.text = "Use";
            PlayerPrefs.SetInt("ShorthairPrice", shorthairPrice);
            PlayerPrefs.SetInt("HighFish", totalFish);
            PlayerPrefs.Save();
        }
        else
        {

            insufficientCoins.SetActive(true);
        }
    }

    public void BackToMap()
    {
        Application.LoadLevel(mapLevel);
    }

    public void PlayDefault()
    {
        selectedPlayer = 0;
        PlayerPrefs.SetInt("SelectedPlayer", selectedPlayer);
    }

    public void PlayBengal()
    {
        selectedPlayer = 1;
        PlayerPrefs.SetInt("SelectedPlayer", selectedPlayer);
    }

    public void PlayNorwegian()
    {
        selectedPlayer = 2;
        PlayerPrefs.SetInt("SelectedPlayer", selectedPlayer);
    }

    public void PlayShortHair()
    {
        selectedPlayer = 3;
        PlayerPrefs.SetInt("SelectedPlayer", selectedPlayer);
    }

}
