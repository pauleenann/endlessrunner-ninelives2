using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public GameObject pooledObject;
    //number of objects na iinitiate once game is played
    public int pooledAmount;
    //list of gameobjects; 
    //to store pooled objects
    List<GameObject> pooledObjects;
    
    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();


        for(int i = 0; i < pooledAmount; i++)
        {
            //converts instantiated object to game object
            GameObject obj = (GameObject)Instantiate(pooledObject);
            obj.SetActive(false);
            //add object to list
            pooledObjects.Add(obj);
            Debug.Log("pooledobjectscount: " +pooledObjects.Count);     
        }
    }

    
    public GameObject GetPooledObject()
    {
        for(int i = 0; i < pooledObjects.Count; i++)
        {
            //if not active, then return pooledObject
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i]; 
            }
        }

        GameObject obj = (GameObject)Instantiate(pooledObject);
        obj.SetActive(false);
        pooledObjects.Add(obj);

        return obj;
    }
}
