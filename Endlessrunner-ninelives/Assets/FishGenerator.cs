using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishGenerator : MonoBehaviour
{
    public ObjectPooler fishPool;

    public float distanceBetweenFish;

    public void SpawnFish(Vector3 startPosition)
    {
        GameObject fish = fishPool.GetPooledObject();
        fish.transform.position = startPosition;
        fish.SetActive(true);
    }
}
