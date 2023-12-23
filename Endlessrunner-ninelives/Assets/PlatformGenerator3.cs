using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator3 : MonoBehaviour
{
    public GameObject thePlatform;
    public Transform generationPoint;
    public float distanceBetween;

    //measures platform width
    private float platformWidth;

    // Start is called before the first frame update
    void Start()
    {
        //how wide our platform is
        platformWidth = thePlatform.GetComponent<PolygonCollider2D>().bounds.size.x;
        Debug.Log(transform.position.x);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = transform.position kung saan nakaattach tong scriptna to
        if(transform.position.x < generationPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y,transform.position.z);
            Instantiate(thePlatform, transform.position, transform.rotation);
        }
    }
}
