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


    void Start()
    {
        selectedPlayer = PlayerPrefs.GetInt("SelectedPlayer", 0);

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
            fishText.text = "" + totalFish;
            adoptNorwegian.text = "Use";
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
            fishText.text = "" + totalFish;
            adoptShorthair.text = "Use";
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
