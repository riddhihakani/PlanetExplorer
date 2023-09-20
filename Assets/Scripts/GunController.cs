using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bulletPrefab;       // Reference to the bullet prefab.
    public Transform bulletSpawnPoint;    // Reference to the spawn point for bullets.
    public float rotationSpeed = 90.0f;   // Rotation speed in degrees per second.
    public float fireInterval = 2.0f;     // Time interval between firing bullets (in seconds).
    public float bulletSpeed = 15.0f;  
    private float currentRotation = 0.0f; // Current rotation of the gun.
    private float lastFireTime = 0.0f;   // Time when the last bullet was fired.
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentRotation += rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0, currentRotation);

        // Check if it's time to fire a bullet.
        if (Time.time - lastFireTime >= fireInterval)
        {
            FireBullet();
            lastFireTime = Time.time;
        }
    }

     private void FireBullet()
    {
        // Instantiate a bullet at the spawn point.
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

        // Set the bullet's initial velocity (you can adjust this as needed).
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = bulletSpawnPoint.up * bulletSpeed; // Adjust the bullet speed as needed.
    }

    
}
