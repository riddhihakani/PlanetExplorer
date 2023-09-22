using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTwoController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector3 currentScale;
    private int hit;
    public GameObject targetObject;
    // private GameManager gameManager;
    // public float shrinkAmount = 0.5f;
    // public float minSize = 1.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentScale = transform.localScale;
        hit = 0;
        // gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
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
        if(other!=null)
        {
             if (other.CompareTag("GreenFood"))
            {
                // Destroy the green diamond.
                if (currentScale.x < 3.0f || currentScale.y < 3.0f){
                    currentScale.x += 0.5f;
                    currentScale.y += 0.5f;
                    transform.localScale = currentScale;
                   
                }
                Destroy(other.gameObject);
            }
            else if (other.CompareTag("PinkFood"))
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
                hit++;
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
            else if(other.CompareTag("FinalPlanet")){
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     // Check if the player enters the trigger zone of the object you want to react to.
    //     if (other.CompareTag("Planet"))
    //     {
    //         // Reduce the player's scale.
    //         //transform.localScale = originalScale * shrinkScale;
    //         Vector3 newScale = transform.localScale - new Vector3(shrinkAmount, shrinkAmount, 0f);
    //         // Ensure that the player's scale doesn't go below a minimum size (optional).
    //         newScale = Vector3.Max(newScale, new Vector3(minSize, minSize, minSize));
    //         if (newScale.x <= minSize)
    //         {
    //             // Game over condition
    //             GameOver();
    //         } else {
    //             transform.localScale = newScale;
    //         }
    //     }
    // }


    // void GameOver()
    // {
        
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    // }
}
