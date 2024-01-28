using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //gaano kabilis
    public float moveSpeed;
    private float moveSpeedStore;
    //multiplies increasing speed over time
    public float speedMultiplier;

    //distance at which the player's speed increases
    public float speedIncreaseMilestone;
    //Keeps track of the distance covered by the player.
    private float speedIncreaseMilestoneStore;

    private float speedMilestoneCount;
    private float speedMilestoneCountStore;

    public float jumpForce;

    //how long the space bar is pressed down
    public float jumpTime;
    private float jumpTimeCounter;


    private Rigidbody2D myRigidbody;

    //checks if player is grounded
    public bool grounded;
    //determines what is ground
    //katulad sa layers
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float groundCheckRadius;

    //private Collider2D myCollider;


    private Animator myAnimator;

    public GameManager theGameManager;

    public AudioSource jumpSound;
    public AudioSource deathSound;

    private bool jumpingStop;

    void Start()
    {
        //search object kung saan tong script nakaattach for the rigidbody2d
        myRigidbody = GetComponent<Rigidbody2D>();
       //myCollider = GetComponent<Collider2D>();
       //finds the animator kung saan nakaattach tong script
        myAnimator = GetComponent <Animator>();
        jumpTimeCounter = jumpTime;
        //ito ung sinet mo sa unity
        speedMilestoneCount = speedIncreaseMilestone;
        moveSpeedStore = moveSpeed;
        speedMilestoneCountStore = speedMilestoneCount;
        speedIncreaseMilestoneStore = speedIncreaseMilestone;
        jumpingStop = true;
    }

    // Update is called once per frame
    void Update()
    {

        //returns true or false
        //checks whether the player is on the ground
        //grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        //determines whether player is grounded
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        //speeds up player
        //pag ung position x, lumagpas sa speedMilestoneCount, magsspeed up na ung playe
        if (transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;
            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
            moveSpeed = moveSpeed * speedMultiplier;
        }

        //velocity is the player's speed
        //vector2 - x and y values (x,y)
        //ito yung magpapaforward sa player
        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);

        //if any input is taken and its "space"
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            //if not grounded, player will not jump
            if (grounded)
            {
                //this will make the player jump
                //change gravity in unity if you want player to fall a little bit faster
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                jumpingStop = false;
                jumpSound.Play();
            }
        }

        //GetKey = kung nakahold ba
        //jumps higher pag nakahold
        if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) && !jumpingStop){
            if(jumpTimeCounter > 0)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        
        if(Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            jumpTimeCounter = 0;
            jumpingStop = true;
        }

        if(grounded)
        {
            jumpTimeCounter = jumpTime;
        }

        //ito ung gagamitin sa speed at grounded value na nasa animator
        myAnimator.SetFloat("Speed", myRigidbody.velocity.x);
        myAnimator.SetBool("Grounded", grounded);
    }

    //when one object with collider touches one box collider
    //kapag nahulog ung player
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "killbox")
        {
            theGameManager.RestartGame();
            moveSpeed = moveSpeedStore;
            speedMilestoneCount = speedMilestoneCountStore;
            speedIncreaseMilestone = speedIncreaseMilestoneStore;
            deathSound.Play();
        }
    }
}
