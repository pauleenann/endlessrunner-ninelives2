using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishPoints : MonoBehaviour
{
    public int scoreToGive;

    private ScoreManager theScoreManager;


    // Start is called before the first frame update
    void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();

    }

    // Update is called once per frame
    void Update()
    {

    }


    //built in function
    //when something enters the trigger tha has a collider
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            theScoreManager.AddFish(scoreToGive);
            gameObject.SetActive(false);
        }
    }
}
