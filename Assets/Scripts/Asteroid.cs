using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    Rigidbody2D rb2d;

    // Timer Length
    public float timerLength = 10.0f;
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
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        // Damage player
        if (player != null)
        {
            player.ChangeHealth(-1);
        }

        Destroy(gameObject);
    }
}
