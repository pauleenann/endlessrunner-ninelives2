using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PurchaseMaps : MonoBehaviour
{
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI fishText;
    public int totalCoins;
    public int totalFish;
    // Start is called before the first frame update
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

    }

    // Update is called once per frame
    void Update()
    {

    }
}
