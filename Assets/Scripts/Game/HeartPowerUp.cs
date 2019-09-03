using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPowerUp : MonoBehaviour
{

    // Add health if player collides with heart
    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>(); // Player Controller

        if (player != null) // Check if player
        {
            player.ChangeHealth(1); // Add health
            Destroy(gameObject); // Destroy Object
        }
    }
}
