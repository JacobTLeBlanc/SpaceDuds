using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinityPowerUp : MonoBehaviour
{
    float length = 30.0f; // Length of powerup

    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>(); // Player Controller

        if (player != null) // Check if player
        {
            // Set powerup to true
            player.infiniteShot = true;
            player.infiniteShotTimer = length;

            // Change bullet delay
            player.timeBullet = 0.5f;

            // Destroy PowerUp
            Destroy(gameObject);
        }
    }
}
