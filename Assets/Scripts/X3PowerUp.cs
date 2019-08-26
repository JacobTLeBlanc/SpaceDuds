using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class X3PowerUp : MonoBehaviour
{
    float length = 30.0f;

    void OnCollisionEnter2D(Collision2D other)
    {
         PlayerController player = other.gameObject.GetComponent<PlayerController>();

         if (player != null) 
         {
             player.tripleShot = true;
             player.tripleShotTimer = length;
             Destroy(gameObject);
         }
    }
}
