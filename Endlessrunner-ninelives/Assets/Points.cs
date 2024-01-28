using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{

    public int scoreToGive;
    Rigidbody2D rb;
    bool hasTarget;
    Vector3 targetPosition;
    
   
    public float speed = 5f;

    private ScoreManager theScoreManager;
    [SerializeField]
    public AudioSource pointSound;



    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate(){
        if(hasTarget){
            Vector2 targetDirection = (targetPosition - transform.position).normalized;
            rb.velocity = new Vector2(targetDirection.x, targetDirection.y) * speed;
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
        if(other.gameObject.name == "Player" || other.gameObject.name == "Bengal" || other.gameObject.name == "Norwegian" || other.gameObject.name == "Shorthair")
        {
            theScoreManager.AddScore(scoreToGive);
            gameObject.SetActive(false);
            pointSound.Play();
        }
    }
}
