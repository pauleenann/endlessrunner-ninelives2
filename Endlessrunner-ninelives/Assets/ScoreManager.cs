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

    public int coinCount;
    public int highCoinCount;
    public float scoreCount;
    public float highScoreCount;

    public float pointsPerSecond;

    public bool scoreIncreasing;
    
    // Start is called before the first frame update
    void Start()
    {
        //shows highscore in the previous game
        if(PlayerPrefs.HasKey("HighScore"))
        {
            highScoreCount = PlayerPrefs.GetFloat("HighScore");
        }

        if (PlayerPrefs.HasKey("HighCoin"))
        {
            highCoinCount = PlayerPrefs.GetInt("HighCoin");
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
        
       


        //rounds decimal value (mathf.round(scorecount)
        scoreText.text = "Score: " + Mathf.Round(scoreCount);
        highScoreText.text = "High Score: " + Mathf.Round(highScoreCount);
        coinsText.text = "Coins: " + highCoinCount;
    }

    public void AddScore(int pointsToAdd)
    {
        coinCount += pointsToAdd;
    }
}
