using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //finds the player 
    //player object has a playercontroler script
    public PlayerController thePlayer;

    //(x,y,z)
    private Vector3 lastPlayerPosition;
    private float distanceToMove;

    // Start is called before the first frame update
    void Start()
    {
        //theplayer's value will be the object that has the playercontroller script
        thePlayer = FindObjectOfType<PlayerController>();
        //assigns the position of theplayer in lastplayervalue
        lastPlayerPosition = thePlayer.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        distanceToMove = thePlayer.transform.position.x - lastPlayerPosition.x;
        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);
        lastPlayerPosition = thePlayer.transform.position;
    }
}
