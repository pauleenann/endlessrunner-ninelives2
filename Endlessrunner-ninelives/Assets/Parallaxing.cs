using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour
{
    float depth = 1;
    PlayerController player;
    public Transform generationPoint;
    public Transform destructionPoint;


    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {

        float speed = player.moveSpeed / depth;
        speed *= 0.2f;
        Vector2 pos = transform.position;

        pos.x -= speed * Time.fixedDeltaTime;

        if (pos.x <= destructionPoint.position.x + 1f)
            pos.x = generationPoint.position.x +5f;

        transform.position = pos;
    }
}
