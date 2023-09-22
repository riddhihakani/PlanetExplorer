using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the colliding object has exited the boundary.
        if (other.CompareTag("PinkPlayer") || other.CompareTag("GreenPlayer"))
        {
            // You can destroy the object or reset its position.
            // For resetting the position:
            other.transform.position = Vector2.zero; // Place the object at the center of the game area.
        }
    }
}
