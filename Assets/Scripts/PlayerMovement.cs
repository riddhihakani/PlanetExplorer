using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    // private int playerSize = 3; 
    // private int planetCollisions = 0; 
    public float moveSpeed = 5.0f; // Adjust the movement speed as needed.
    private Rigidbody2D rb;
    private Vector3 originalScale;
    public float shrinkAmount = 0.5f;
    public float minSize = 1.0f;
    //private bool gameOver = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;
        // gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(0f, verticalInput);
        rb.velocity = movement * moveSpeed;
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other!=null)
        {
            if (other.CompareTag("PinkFood"))
            {
                // Destroy the green diamond.
                Destroy(other.gameObject);
            }
            else if (other.CompareTag("GreenFood"))
            {
                // Reduce player size.
                // playerSize--;
                // if (playerSize <= 0)
                // {
                //     // Game over, restart the scene.
                //     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                // }
                Debug.Log("Different Color");
            }
            else if (other.CompareTag("Planet"))
            {
                Debug.Log("Collision");
                Vector3 currentScale = transform.localScale;
                currentScale.x -= 0.5f;
                currentScale.y -= 0.5f;
                transform.localScale = currentScale;

                if (currentScale.x <= 0.5 || currentScale.y <= 0.5)
                {
                    // Player has shrunk too much, game over, restart the scene.
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
                
            }

            if (other.gameObject.CompareTag("Bullet"))
            {
                Debug.Log("Bullet hit player1");
                GameManager.Instance.PlayerHit(gameObject); 
                Destroy(other.gameObject);
            }
        }
    }
        
    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     // Check if the player enters the trigger zone of the object you want to react to.
    //     if (other.CompareTag("Planet"))
    //     {
            
    //         Vector3 newScale = transform.localScale - new Vector3(shrinkAmount, shrinkAmount, 0f);
        
    //         newScale = Vector3.Max(newScale, new Vector3(minSize, minSize, minSize));
            
    //         if (newScale.x <= minSize)
    //         {
    //             // Game over condition
    //             GameOver();
    //         }else{
    //             transform.localScale = newScale;
    //         }
    //     }
    // }


    // void GameOver()
    // {
        
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    // }
}
