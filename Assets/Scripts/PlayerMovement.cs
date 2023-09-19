using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5.0f; // Adjust the movement speed as needed.
    private Rigidbody2D rb;
    private Vector3 originalScale;
    public float shrinkAmount = 0.3f;
    public float minSize = 0.5f;
    //private bool gameOver = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        rb.velocity = movement * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player enters the trigger zone of the object you want to react to.
        if (other.CompareTag("Planet"))
        {
            // Reduce the player's scale.
            //transform.localScale = originalScale * shrinkScale;
            Vector3 newScale = transform.localScale - new Vector3(shrinkAmount, shrinkAmount, 0f);
            // Ensure that the player's scale doesn't go below a minimum size (optional).
            newScale = Vector3.Max(newScale, new Vector3(minSize, minSize, minSize));
            transform.localScale = newScale;
            if (transform.localScale.x <= minSize)
            {
                // Game over condition
                GameOver();
            }
        }
    }


    void GameOver()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
