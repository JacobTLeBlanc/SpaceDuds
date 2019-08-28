using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // If player touches coin, add to total and destroy coin
    void OnCollisionEnter2D(Collision2D other)
    {

        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            GameControl.instance.addCoin();
            Destroy(gameObject);
        }
    }
}
