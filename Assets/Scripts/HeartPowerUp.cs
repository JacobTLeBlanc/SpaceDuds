﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPowerUp : MonoBehaviour
{

    // Add health if player collides with heart
    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            player.ChangeHealth(1);
            Destroy(gameObject);
        }
    }
}