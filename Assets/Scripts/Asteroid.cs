using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    Rigidbody2D rb2d;

    // Timer Length
    public float timerLength = 5.0f;
    float destroyTimer = 0.0f; // Timer
    

    // Start is called before the first frame update
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>(); // Get RigidBody2D component
        destroyTimer = timerLength; // Set timer to full length
    }

    // Update is called once per frame
    void Update()
    {
        // Update timer every frame
        destroyTimer -= Time.deltaTime;
        // If timer reaches 0, destroy asteroid
        if (destroyTimer < 0)
        {
            Destroy(gameObject);
        }
    }

    // Detect collision
    void OnCollisionEnter2D(Collision2D other)
    {
        // Check if object is bullet or already destroyed asteroid
        Projectile bullet = other.gameObject.GetComponent<Projectile>();
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        DestroyedAsteroid destroyed = gameObject.GetComponent<DestroyedAsteroid>();

        if (bullet != null && destroyed == null)
        {
            // Turn astroid into 1-3 pieces
            int Rand = Random.Range(1, 4);

            // Create new asteroids
            for (int i = 0; i < Rand; i++)
            {
                breakAsteroid();
            }
        }
        
        // Damage player
        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }

    void breakAsteroid()
    {
        // Create new asteroid
        GameObject newAst = Instantiate(gameObject, this.transform.position, Quaternion.identity);

        // Scale down new asteroids
        newAst.transform.localScale = this.transform.localScale * Random.Range(0.3f, 0.8f);

        // Add destroyedAsteroid script
        newAst.AddComponent<DestroyedAsteroid>();
    }

    

}
