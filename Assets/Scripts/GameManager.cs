using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance;

    public int maxHits = 1; // Maximum number of hits before the game ends

    private int player1Hits;
    private int player2Hits;
    

    void Start()
    {
        player1Hits = 0;
        player2Hits = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerHit(int playerNumber){
        if (playerNumber == 1)
        {
            Debug.Log("Pink was hit");
            player1Hits++;
        }
        else if (playerNumber == 2)
        {
            Debug.Log("Green was hit");
            player2Hits++;
        }

        // Check if both players have been hit maxHits times
        if (player1Hits >= maxHits && player2Hits >= maxHits)
        {
            // Game over, restart the scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
