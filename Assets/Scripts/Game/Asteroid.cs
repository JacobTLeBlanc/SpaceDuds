using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
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

        // Random spawns
        GameControl.instance.spawnCoin(5, this.transform.position);
        GameControl.instance.spawnPowerUp(100, this.transform.position);

        // Destroy asteroid
        Destroy(gameObject);
    }
}
