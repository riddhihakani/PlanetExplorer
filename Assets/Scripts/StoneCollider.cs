using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneCollider : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1.0f;
    public float minX = -5.0f;
    public float maxX = 5.0f;
    public float minY = -5.0f;
    public float maxY = 5.0f;

    private Vector2 targetPosition;
    void Start()
    {
        GenerateRandomTarget();
    }

    void GenerateRandomTarget()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        targetPosition = new Vector2(randomX, randomY);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // Check if the object has reached the target
        if ((Vector2)transform.position == targetPosition)
        {
            // Generate a new random target position
            GenerateRandomTarget();
        }
    }
}
