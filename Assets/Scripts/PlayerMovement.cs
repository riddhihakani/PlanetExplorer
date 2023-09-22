using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
   
    public float moveSpeed = 5.0f; // Adjust the movement speed as needed.
    private Rigidbody2D rb;
    private Vector3 currentScale;
   
    // public Transform connectionPoint;
    public GameObject targetObject;
    // public GameObject playerToMove; 
    

    // private TextDisplay textDisplay;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentScale = transform.localScale;
       
        
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
                if (currentScale.x < 3.0f || currentScale.y < 3.0f){
                    currentScale.x += 0.5f;
                    currentScale.y += 0.5f;
                    transform.localScale = currentScale;
                   
                }
                Destroy(other.gameObject);
            }
            else if (other.CompareTag("GreenFood"))
            {
               
                Debug.Log("Different Color");
            }
            else if (other.CompareTag("Planet"))
            {
                Debug.Log("Collision");

                if (currentScale.x <= 1.0f || currentScale.y <= 1.0f)
                {
                    // Player has shrunk too much, game over, restart the scene.
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }else{
                    currentScale.x -= 0.5f;
                    currentScale.y -= 0.5f;
                    transform.localScale = currentScale;
                }
                
            }
            else if (other.gameObject.CompareTag("Bullet"))
            {
                Debug.Log("Bullet hit player1");
                // gameManager.PlayerHit(1); 
                // Destroy(other.gameObject);
         
                if(currentScale.x <= 1.0f || currentScale.y <= 1.0f){
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }else{
                    currentScale.x -= 0.5f;
                    currentScale.y -= 0.5f;
                    transform.localScale = currentScale;
                }
                
            }
            else if(other.gameObject.CompareTag("Gold"))
            {
                if (currentScale.x < 3.0f || currentScale.y < 3.0f){
                    currentScale.x += 0.5f;
                    currentScale.y += 0.5f;
                    transform.localScale = currentScale;
                    Destroy(other.gameObject);
                }
                
            }
            else if(other.CompareTag("Stone"))
            {
                // Increase the length of the Hinge Joint by modifying the connectedAnchor.
                Debug.Log("in stone");
                // connectionPoint.Translate(Vector2.up * 1.5f); 
                Transform targetTransform = targetObject.transform.Find("string");
                GameObject targetChildObject = targetTransform.gameObject;
                Vector3 newScale = targetChildObject.transform.localScale;
                if(newScale.x <= 0.5f){
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }else{
                    newScale.x -= 0.5f; // Increase the length (adjust as needed).
                    targetChildObject.transform.localScale = newScale;
                }
                
            }
            else if(other.CompareTag("FinalPlanet"))
            {
                // textDisplay.DisplayWinMessage();
                Invoke("RestartGame", 2f);
            }
        }
    }
        
    private void RestartGame()
    {
        // Reload the current scene to restart the game.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}
