using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinMessage : MonoBehaviour
{
    // Start is called before the first frame update
    public Text winText;
    void Start()
    {
        winText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayWinMessage()
    {
        winText.gameObject.SetActive(true);
        winText.text = "You Win"; // Set the text content.

        Invoke("RestartGame", 2f);
    }

    private void RestartGame()
    {
        // Reload the current scene to restart the game.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
