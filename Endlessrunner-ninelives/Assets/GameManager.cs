using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public TextMeshProUGUI livesText;
    public int totalLivesLeft;
    public int maxLives = 9;

    public PlayerController thePlayer;
    private Vector3 playerStartPoint;

    private PlatformDestroyer[] platformList;

    private ScoreManager theScoreManager;

    public DeathMenu deathScreen;




    // Start is called before the first frame update
    void Start()
    {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;
        theScoreManager = FindObjectOfType<ScoreManager>();
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
            deathScreen.gameObject.SetActive(true);
        }
    }

    public void Reset()
    {

        deathScreen.gameObject.SetActive(false);
        livesText.text = "Lives: " + maxLives;
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
