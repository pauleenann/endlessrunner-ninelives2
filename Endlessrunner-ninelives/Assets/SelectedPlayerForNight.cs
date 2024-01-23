using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedPlayerForNight : MonoBehaviour
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

        players[selectedPlayer].SetActive(true);

    }
}
