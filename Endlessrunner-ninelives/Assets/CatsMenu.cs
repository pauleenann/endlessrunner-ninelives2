using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CatsMenu : MonoBehaviour
{
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI fishText;
    public int totalCoins;
    public int totalFish;
    public string mainMenuLevel;
    public int bengalPrice;
    public int norwegianPrice;
    public int shorthairPrice;
    public GameObject insufficientCoins;
    public GameObject mapUnlocked;

    public GameObject[] catsPanel;
    public GameObject[] catsDescription; 


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
        
    }

    public void bengalDesc()
    {
        if (totalCoins >= bengalPrice)
        {
            mapUnlocked.SetActive(true);
        }

        else
        {

            insufficientCoins.SetActive(true);
        }
    }
}
