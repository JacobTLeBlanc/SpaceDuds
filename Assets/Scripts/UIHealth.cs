﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    // Instance
    public static UIHealth instance { get; private set; }
    // Hearts
    public GameObject[] hearts = new GameObject[3];

    // Start is called before the first frame update
    void Awake()
    {
        // Make this object the only instance
        instance = this;
    }

    // Update heart method
    public void updateHearts(int currentHealth)
    {
        // Check if hearts should be displayed based on current health
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth) {
                hearts[i].active = true;
            } else {
                hearts[i].active = false;
            }
        }
    }
}