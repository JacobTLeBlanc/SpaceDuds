using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.1f; // Player speed

    public GameObject bulletPrefab; // Bullet Prefab
    Rigidbody2D rb2d; 
    float horizontal; 
    float vertical;

    int health;
    int maxHealth = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); // Get RigidBody component

        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        // Get input from gyroscope
        horizontal = Input.acceleration.x;

        // Check if screen is touched is pressed then fire
        for (int i = 0; i < Input.touchCount; i++)
        {
            if(Input.GetTouch(i).phase == TouchPhase.Began)
            {
                Fire();
            }
        }
    }

    // Used Fixed Update to smooth movement
    void FixedUpdate() 
    {
        // Use input to change position 
        Vector2 move = new Vector2(horizontal, -3);
        Vector2 position = rb2d.position;
        position = position + move * speed * Time.deltaTime;
        rb2d.position = position;
    }

    // Fire method
    void Fire()
    {
        // Create bullet object
        GameObject bulletObject = Instantiate(bulletPrefab, rb2d.position + Vector2.up * 0.5f, Quaternion.identity);
        Vector2 direction = new Vector2(0, 1);

        // Call launch method on bullet
        Projectile projectile = bulletObject.GetComponent<Projectile>();
        projectile.Launch(direction, 300.0f);
    }

}
