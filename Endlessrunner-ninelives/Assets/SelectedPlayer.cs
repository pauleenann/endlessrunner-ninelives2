using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedPlayer : MonoBehaviour
{
    [SerializeField]
    public GameObject[] players;
    public int selectedPlayer;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("SelectedPlayer"))
        {
            selectedPlayer = PlayerPrefs.GetInt("SelectedPlayer");
        }

        // Deactivate all players
        foreach (GameObject player in players)
        {
            player.SetActive(false);
        }

        // Activate the selected player
        players[selectedPlayer].SetActive(true);
    }

}
