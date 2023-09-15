using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5.0f; // Adjust the movement speed as needed.
    private Rigidbody2D rb;
    private Vector3 originalScale;
    public float shrinkScale = 0.8f;
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
            transform.localScale = originalScale * shrinkScale;
        }
    }
}
