using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{

    public int scoreToGive;
    Rigidbody2D rb;
    bool hasTarget;
    Vector3 targetPosition;

    private ScoreManager theScoreManager;


    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate(){
        if(hasTarget){
            Vector2 targetDirection = (targetPosition - transform.position).normalized;
            rb.velocity = new Vector2(targetDirection.x, targetDirection.y) * 5f;
        }
    }

    public void SetTarget(Vector3 position){
        targetPosition = position;
        hasTarget = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();

    }

    //built in function
    //when something enters the trigger tha has a collider
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            theScoreManager.AddScore(scoreToGive);
            gameObject.SetActive(false);
        }
    }
}
