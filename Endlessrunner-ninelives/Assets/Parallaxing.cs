using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour
{
    float depth = 1;
    public float speedController;
    PlayerController player;
    public Transform generationPoint;
    public Transform destructionPoint; 
    private ScoreManager theScoreManager;
    [SerializeField]
    public string[] selectedPlayerString = { "Player", "Bengal", "Norwegian", "Shorthair" };
    public int selectedPlayer;

    void Awake()
    {
        if (PlayerPrefs.HasKey("SelectedPlayer"))
        {
            selectedPlayer = PlayerPrefs.GetInt("SelectedPlayer");
        }

        player = GameObject.Find(selectedPlayerString[selectedPlayer]).GetComponent<PlayerController>();
        Debug.Log(selectedPlayerString[selectedPlayer]);
    }

    void Update()
    {

        float speed = player.moveSpeed / depth;
        speed *= speedController;

        Vector2 pos = transform.position;

        pos.x -= speed * Time.fixedDeltaTime;

        if (pos.x <= destructionPoint.position.x + 1f)
            pos.x = generationPoint.position.x +5f;

        transform.position = pos;
    }
}
