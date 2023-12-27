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
    //public GameObject[] thePlatforms;
    private float[] platformWidths;

    public ObjectPooler[] theObjectPools;

    //height of the platformgenerator
    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;

    private CoinGenerator theCoinGenerator;
    private FishGenerator theFishGenerator;

    private int randomCoinSpawn;
    private int randomFishSpawn;
    public int randomizer;


    // Start is called before the first frame update
    void Start()
    {
        //how wide our platform is
        //platformWidth = theObjectPool.GetComponent<PolygonCollider2D>().bounds.size.x;
        platformWidths = new float[theObjectPools.Length];
        Debug.Log(transform.position.x);
        //Debug.Log(thePlatforms.Length);

        //platformwidth does not have a value yet idk why
        for (int i = 0; i < theObjectPools.Length; i++)
        {
            //mali to di ko alam bat di nakukuha ung size.x
            platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
            
        }

        //kung saan nakalagay ung platform generator
        minHeight = transform.position.y;
        //position.y ng maxheightpoiunt
        maxHeight = maxHeightPoint.position.y;

        theCoinGenerator = FindObjectOfType<CoinGenerator>();
        theFishGenerator = FindObjectOfType<FishGenerator>();
        randomizer = Random.Range(61, 100);
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
            Debug.Log("distance between: " + distanceBetween);

            platformSelector = Random.Range(0, theObjectPools.Length);
            
            Debug.Log("plwidth: " + platformWidths[platformSelector]);

            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);
            //new transform.position ng platformgenerator
            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector]/3) + distanceBetween, heightChange, transform.position.z);
            Debug.Log("pw+db: " + ((platformWidths[platformSelector] / 2) + distanceBetween));
            Debug.Log(transform.position);


            //Instantiate(/*thePlatform*/thePlatforms[platformSelector], transform.position, transform.rotation);

            GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            int randomSpawn = Random.Range(0, 100);

            if (randomSpawn < randomizer)
            {
                // Spawn coin
                theCoinGenerator.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 6f, transform.position.z));
            }
            else
            {
                // Spawn fish
                theFishGenerator.SpawnFish(new Vector3(transform.position.x, transform.position.y + 6f, transform.position.z));
            }


            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);
        }
    }
}
