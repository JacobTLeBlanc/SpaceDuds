using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class X3PowerUp : MonoBehaviour
{
    float length = 30.0f; // Length of PowerUp

    void OnCollisionEnter2D(Collision2D other)
    {
         PlayerController player = other.gameObject.GetComponent<PlayerController>(); // PlayerController

         if (player != null) // Check if player
         {
             // Turn on TripleShot
             player.tripleShot = true;
             player.tripleShotTimer = length;

             // Destroy Object
             Destroy(gameObject);
         }
    }
}
