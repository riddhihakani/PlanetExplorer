using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player collided with the diamond.
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player touched the diamond");
            // Deactivate (hide) the diamond.
            gameObject.SetActive(false);
        }
    }
}
