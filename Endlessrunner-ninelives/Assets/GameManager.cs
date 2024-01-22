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


    // Start is called before the first frame update
    void Start()
    {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;
        theScoreManager = FindObjectOfType<ScoreManager>();
        scoreCounter = theScoreManager.scoreCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame()
    {
        if(maxLives > 0)
        {
          
            maxLives--;
            
            //stops scoring
            theScoreManager.scoreIncreasing = false;
            //player object will be inactive
            thePlayer.gameObject.SetActive(false);
            ////coroutine - runs by itself; you add som time delays
            //StartCoroutine("RestartGameCo");

            //deathScreen.gameObject.SetActive(true);
            resumeScreen.gameObject.SetActive(true);
        }
        else
        {
            deathScreen.gameObject.SetActive(true);
        }
        
        
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

    /*public IEnumerator RestartGameCo()
    {
        //stops scoring
        theScoreManager.scoreIncreasing = false;
        //player object will be inactive
        thePlayer.gameObject.SetActive(false);
        //adds delay to ur coroutine
        yield return new WaitForSeconds(0.5f);
        platformList = FindObjectsOfType<PlatformDestroyer>();

        for(int i = 0; i < platformList.Length; i++)
        {
            //makes object invisible
            platformList[i].gameObject.SetActive(false);
        }

        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);

        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;
    }*/
}
