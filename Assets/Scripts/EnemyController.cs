using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject bulletPrefab;       // Reference to the bullet prefab.
    public float moveDistance = 5.0f;     // Horizontal distance the gun will move.
    public float moveSpeed = 2.0f;        // Movement speed in units per second.
    public float bulletSpeed = 15.0f;     // Initial speed of the bullets.
    public float fireInterval = 2.0f;     // Time interval between firing bullets (in seconds).

    private Vector3 startPosition;        // The starting position of the gun.
    private bool movingRight = true;       // Flag to determine movement direction.
    private float lastFireTime = 0.0f;    // Time when the last bullet was fired.
    private Transform bulletSpawnPoint;   // Reference to the bullet spawn point.

    void Start()
    {
        startPosition = transform.position;
        bulletSpawnPoint = transform.Find("BulletSpawnPoint");
    }

    // Update is called once per frame
    void Update()
    {
         // Move the gun horizontally.
        if (movingRight)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            if (transform.position.x >= startPosition.x + moveDistance)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            if (transform.position.x <= startPosition.x)
            {
                movingRight = true;
            }
        }

        // Check if it's time to fire a bullet.
        if (Time.time - lastFireTime >= fireInterval)
        {
            FireBullet();
            lastFireTime = Time.time;
        }
    }

    private void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

        // Set the bullet's initial velocity in the upward direction.
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * bulletSpeed; 
    }
}
