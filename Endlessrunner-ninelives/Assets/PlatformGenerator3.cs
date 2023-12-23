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

    public float distanceBetweenMin;
    public float distanceBetweenMax;

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
        //transform.position = transform.position kung saan nakaattach tong script na to
        //the generationpoint holds holds the transform value ng object na nakaattach sa kanya
        if(transform.position.x < generationPoint.position.x)
        {
            //pick number between distanceBetweenMin and Max
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
            //new transform.position ng platformgenerator
            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y,transform.position.z);
            Instantiate(thePlatform, transform.position, transform.rotation);
        }
    }
}
