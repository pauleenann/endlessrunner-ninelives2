using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    public Transform platformGenerator;
    private Vector3 platformStartPoint;
    private Vector3 platformLastPoint;

    public TextMeshProUGUI livesText;
    public int totalLivesLeft;
    public int maxLives = 9;
    public Image[] lives;
    public Sprite hasLives;
    public Sprite blankLives;

    public PlayerController thePlayer;
    private Vector3 playerStartPoint;

    private PlatformDestroyer[] platformList;

    private ScoreManager theScoreManager;

    public DeathMenu deathScreen;

    public GameObject resumeScreen;
    private float scoreCounter;

    public GameObject[] playerArray;

    private const string LivesKey = "PlayerLives";
    private const string LastLifeLostTimeKey = "LastLifeLostTime";

    // Start is called before the first frame update
    void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
        scoreCounter = theScoreManager.scoreCount;

        // Load player data and update UI
        LoadPlayerData();

        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;

        // Update the UI to reflect the initial lives count
        UpdateLivesUI();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RestartGame()
    {
        if (maxLives > 0)
        {
            maxLives--;
            SavePlayerData(); // Save the updated lives count
            PlayerPrefs.SetString(LastLifeLostTimeKey, DateTime.Now.ToString()); // Save the time when the life was lost

            // Update the UI to reflect the lost life
            UpdateLivesUI();

            theScoreManager.scoreIncreasing = false;
            thePlayer.gameObject.SetActive(false);
            resumeScreen.gameObject.SetActive(true);

            StartCoroutine(RechargeLifeAfterDelay());
        }
        else
        {
            deathScreen.gameObject.SetActive(true);
        }
    }

    private void UpdateLivesUI()
    {
        Debug.Log("Updating Lives UI. Max Lives: " + maxLives);
        for (int i = 0; i < lives.Length; i++)
        {
            if (i < maxLives)
            {
                lives[i].sprite = hasLives;
            }
            else
            {
                lives[i].sprite = blankLives;
            }
        }
    }

    private IEnumerator RechargeLifeAfterDelay()
    {
        yield return new WaitForSeconds(60f); // Wait for 60 seconds

        // Recharge one life after the delay
        maxLives = Mathf.Min(maxLives + 1, 9); // Cap the lives at 9
        SavePlayerData(); // Save the updated lives count
    }

    public void Reset()
    {
        //deathScreen.gameObject.SetActive(false);

        //livesText.text = "Lives: " + maxLives;

        platformList = FindObjectsOfType<PlatformDestroyer>();

        for (int i = 0; i < platformList.Length; i++)
        {
            //makes object invisible
            platformList[i].gameObject.SetActive(false);
        }

        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);

        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;
    }

    public void Resume()
    {
        foreach (Image img in lives)
        {
            img.sprite = blankLives;
        }
        for (int i = 0; i < maxLives; i++)
        {
            lives[i].sprite = hasLives;
        }
        //maxLives--;
        //livesText.text = "Lives: " + maxLives;

        // Find the Main Camera
        Camera mainCamera = Camera.main;
        Debug.Log("Main Camera X Position: " + mainCamera.transform.position.x);

        //kung sinong player and marerespawn
        for (int i = 0; i < playerArray.Length; i++)
        {
            if (playerArray[i].activeSelf)
            {
                thePlayer = playerArray[i].GetComponent<PlayerController>();
                // You found an active player, so you can break out of the loop
                break;
            }
        }


        //kung saan maglland ung player pag ginamit ung lives
        thePlayer.transform.position = new Vector3(mainCamera.transform.position.x - 5f, transform.position.y + 6f, transform.position.z);
        theScoreManager.scoreIncreasing = true;
        thePlayer.gameObject.SetActive(true);
    }

    private void LoadPlayerData()
    {
        if (PlayerPrefs.HasKey(LivesKey))
        {
            maxLives = PlayerPrefs.GetInt(LivesKey);

            // Update the UI to reflect the loaded lives count
            UpdateLivesUI();
        }
        else
        {
            maxLives = 9; // Initial lives count
            SavePlayerData(); // Save initial lives count only if there is no saved data
        }

        if (PlayerPrefs.HasKey(LastLifeLostTimeKey))
        {
            string lastLifeLostTimeString = PlayerPrefs.GetString(LastLifeLostTimeKey);
            DateTime lastLifeLostTime = DateTime.Parse(lastLifeLostTimeString);
            TimeSpan timePassed = DateTime.Now - lastLifeLostTime;

            int secondsPassed = (int)timePassed.TotalSeconds;
            if (secondsPassed >= 60)
            {
                maxLives += secondsPassed / 60; // Recharge one life for every 60 seconds passed
                maxLives = Mathf.Min(maxLives, 9); // Cap the lives at 9
                SavePlayerData(); // Save the updated lives count
            }
        }
    }

    private void SavePlayerData()
    {
        PlayerPrefs.SetInt(LivesKey, maxLives);
        PlayerPrefs.Save();
    }
}