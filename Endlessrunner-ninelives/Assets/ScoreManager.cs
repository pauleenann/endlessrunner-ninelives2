using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI fishText;

    public int fishCount;
    public int highFishCount;
    public int coinCount;
    public int highCoinCount;
    public float scoreCount;
    public float highScoreCount;


    public float pointsPerSecond;

    public bool scoreIncreasing;

    
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("HighCoin", 500000);
        PlayerPrefs.SetFloat("HighScore", 0);
        
        //shows highscore in the previous game
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScoreCount = PlayerPrefs.GetFloat("HighScore");
        }

        if (PlayerPrefs.HasKey("HighCoin"))
        {
            highCoinCount = PlayerPrefs.GetInt("HighCoin");
        }

        if (PlayerPrefs.HasKey("HighFish"))
        {
            highFishCount = PlayerPrefs.GetInt("HighFish");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(scoreIncreasing)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;
        }

        if(scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", highScoreCount);
         
        }

        if(coinCount == 2)
        {
            highCoinCount += coinCount;
            PlayerPrefs.SetInt("HighCoin", highCoinCount);
            coinCount = 0;
        }
       
        if(fishCount > 0)
        {
            highFishCount += fishCount;
            PlayerPrefs.SetInt("HighFish", highFishCount);
            fishCount = 0;
        }

        //rounds decimal value (mathf.round(scorecount)
        scoreText.text = Mathf.Round(scoreCount) + "M";
        highScoreText.text = "BEST: " + Mathf.Round(highScoreCount) + "M";
        coinsText.text = ""+highCoinCount;
        fishText.text = "" + highFishCount;
    }

    public void AddScore(int pointsToAdd)
    {
        coinCount += pointsToAdd;
    }

    public void AddFish(int fishToAdd)
    {
        fishCount += fishToAdd;
    }
}
