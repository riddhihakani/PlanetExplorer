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
            

            // Color diamondColor = GetComponent<SpriteRenderer>().material.color;
            // Color playerColor = other.GetComponent<SpriteRenderer>().material.color;
            // Debug.Log(diamondColor);
            // Debug.Log(playerColor);
            SpriteRenderer diamondRenderer = GetComponent<SpriteRenderer>();
            SpriteRenderer playerRenderer = other.GetComponent<SpriteRenderer>();
            if (diamondRenderer != null && playerRenderer != null)
            {
                Color diamondColor =  diamondRenderer.color;
                Color playerColor = playerRenderer.color;
                Debug.Log(diamondColor);
                Debug.Log(playerColor);
                if (diamondColor != playerColor)
                {
                    // Increase the distance between the players connected by the hinge joint.
                    // You can access the Hinge Joint 2D component and change the joint's connectedAnchor property.
                    HingeJoint2D hingeJoint = other.GetComponent<HingeJoint2D>();

                    if (hingeJoint != null)
                    {
                        Debug.Log("Joint is there");
                        // Increase the Y-coordinate of the connected anchor to move the player upwards.
                        Vector2 newConnectedAnchor = hingeJoint.connectedAnchor;
                        Debug.Log(newConnectedAnchor.y);
                        newConnectedAnchor.y += 10.0f; // Adjust the value as needed.
                        hingeJoint.connectedAnchor = newConnectedAnchor;
                    }
                }else{
                    Debug.Log("Color is Same");
                    // gameObject.SetActive(false);
                    Destroy(gameObject);
                }
            }
        }
    }
}
