using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinityPowerUp : MonoBehaviour
{
    float length = 30.0f;

    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if (player != null) 
        {
            player.infiniteShot = true;
            player.infiniteShotTimer = length;
            player.timeBullet = 0.1f;
            Destroy(gameObject);
        }
    }
}
