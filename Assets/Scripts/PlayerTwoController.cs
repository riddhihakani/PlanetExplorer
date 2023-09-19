using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTwoController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector3 originalScale;
    public float shrinkAmount = 0.3f;
    public float minSize = 0.5f;
    void Start()
    {
         rb = GetComponent<Rigidbody2D>();
         originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0f);
        rb.velocity = movement * speed;
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
