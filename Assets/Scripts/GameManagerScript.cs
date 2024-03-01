using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public List<Transform> playerPrefabs = new List<Transform>();

    private PlayerHealth player1;
    private PlayerHealth player2;

    private bool isSinglePlayer()
    {
        return PlayerPrefs.GetInt("selectedCharacter") == 0 || PlayerPrefs.GetInt("selectedCharacter") == 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Instantiate only once object with selected ship
        // get the selected character, which index we know from the selection previously we saved
        int selectedPlayer = PlayerPrefs.GetInt("selectedCharacter");

        // get it from the list we have from the selectedPlayers
        Transform playerPrefab = playerPrefabs[selectedPlayer];

        var playerPref = Instantiate(playerPrefab) as Transform;

        player1 = playerPref.GetComponent<PlayerHealth>();
        player1.isMainPlayer = true;

        // position of the player to spawn
        float xPos = -7.22f;
        float yPos = -0.01f;

        Vector2 pos = new Vector2(xPos, yPos);

        // set Player to that position
        playerPref.position = pos;
    }

    void Update()
    {
        if (player1 == null)
        {
            Debug.Log("The Player died, so please show score screen");
            Application.LoadLevel("ScoreOverview");
        }
        
    }
}
