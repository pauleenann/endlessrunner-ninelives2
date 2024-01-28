using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlatformGenerator : MonoBehaviour
{
    //creates an gameobject array
    public GameObject thePlatform;
    public Transform generationPoint;
    public float distanceBetween;

    private float platformWidth;

    public float distanceBetweenMin;
    public float distanceBetweenMax;

    //public GameObject[] thePlatforms;
    private int platformSelector;
    private float[] platformWidths;

    public ObjectPooler[] theObjectPools;

    private float minHeight;
    public Transform maxHeighPoint;
    private float maxHeight;

    public float maxHeightChange;
    private float heightChange;
    //public float randomCoin;

    private CoinGenerator theCoinGenerator;
    private FishGenerator theFishGenerator;

    private int randomCoinSpawn;
    private int randomFishSpawn;
    public int randomizer;

    public float fishHeight;
    public float coinHeight;

    void Start()
    {
        //platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;

        platformWidths = new float[theObjectPools.Length];
        Debug.Log("platformwidths: " + platformWidths);

        for(int i = 0; i < theObjectPools.Length; i++)
        {
            //gets width of each platform
            platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        //platform height
        minHeight = transform.position.y;
        maxHeight = maxHeighPoint.position.y;


        theCoinGenerator = FindObjectOfType<CoinGenerator>();
        theFishGenerator = FindObjectOfType<FishGenerator>();
        randomizer = Random.Range(61, 100);

    }

    // Update is called once per frame
    void Update()
    {
        //if platform generator is less than the generation point in camera
        if (transform.position.x < generationPoint.position.x)
        {
            //selects a random distance between platforms
            distanceBetween = Random.Range(distanceBetweenMin,distanceBetweenMax);
            //choses what tupe of platform to display
            platformSelector = Random.Range(0, theObjectPools.Length);
            //chooses a random height
            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

            //if ung nagenerate na heigh change ay mas mataas sa maxHeight point, do the following
            if(heightChange > maxHeight)
            {
                heightChange = maxHeight;
            }
            else if(heightChange < minHeight)
            {
                heightChange = minHeight;
            }

            //moves platform generator point
            //transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);
            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector]/2) + distanceBetween, heightChange, transform.position.z);
            Debug.Log("plwidthselector : " + platformWidths[platformSelector]);

            //copies an existing object
            //3 values         
            //Instantiate(/*thePlatform*/thePlatforms[platformSelector], transform.position, transform.rotation);

            GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            int randomSpawn = Random.Range(0, 100);

            if (randomSpawn < randomizer)
            {
                // Spawn coin
                theCoinGenerator.SpawnCoins(new Vector3(transform.position.x, transform.position.y + coinHeight, transform.position.z));
            }
            else
            {
                // Spawn fish
                theFishGenerator.SpawnFish(new Vector3(transform.position.x, transform.position.y + fishHeight, transform.position.z));
            }


            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector]/2), transform.position.y, transform.position.z);
        }
    }
}