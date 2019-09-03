using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // If player touches coin, add to total and destroy coin
    void OnCollisionEnter2D(Collision2D other)
    {

        PlayerController player = other.gameObject.GetComponent<PlayerController>(); // Get Player Controller

        // Check if player
        if (player != null)
        {
            GameControl.instance.addCoin(); // Add coin to counter
            Destroy(gameObject); // Destroy object
        }
    }
}
