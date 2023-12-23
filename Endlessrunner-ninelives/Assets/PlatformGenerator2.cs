using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator2 : MonoBehaviour
{
    public GameObject thePlatform;
    public Transform generationPoint;
    public float distanceBetween;

    //measures platform width
    private float platformWidth;

    public float distanceBetweenMin;
    public float distanceBetweenMax;

    private int platformSelector;
    public GameObject[] thePlatforms;
    private float[] platformWidths;

    //public ObjectPooler theObjectPool;


    // Start is called before the first frame update
    void Start()
    {
        //how wide our platform is
        //platformWidth = thePlatform.GetComponent<PolygonCollider2D>().bounds.size.x;
        platformWidths = new float[thePlatforms.Length];
        Debug.Log(transform.position.x);

        for (int i = 0; i < thePlatforms.Length; i++)
        {
            platformWidths[i] = thePlatforms[i].GetComponent<PolygonCollider2D>().bounds.size.x;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = transform.position kung saan nakaattach tong script na to
        //the generationpoint holds holds the transform value ng object na nakaattach sa kanya
        if (transform.position.x < generationPoint.position.x)
        {
            //pick number between distanceBetweenMin and Max
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            platformSelector = Random.Range(0, thePlatforms.Length);
            //new transform.position ng platformgenerator
            transform.position = new Vector3(transform.position.x + platformWidths[platformSelector] + distanceBetween, transform.position.y, transform.position.z);



            Instantiate(/*thePlatform*/thePlatforms[platformSelector], transform.position, transform.rotation);



            /*GameObject newPlatform = theObjectPool.GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);*/
        }
    }
}
