using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Despawn timer
    float destroyTimer;
    float destroyLength = 10.0f;

    void Start()
    {
        // Start timer
        destroyTimer = destroyLength;
    }

    void Update()
    {
        // Update timer
        destroyTimer -= Time.deltaTime;

        // Despawn once timer reaches 0
        if (destroyTimer < 0)
        {
            Destroy(gameObject);
        }
    }

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
