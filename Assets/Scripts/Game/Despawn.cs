using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
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
        if (GameControl.instance.pause)
        {
            return;
        }
        destroyTimer -= Time.deltaTime;

        // Despawn when timer reaches 0
        if (destroyTimer < 0)
        {
            if (GameControl.instance.pause)
            {
                destroyTimer = 30.0f;
            }


            DestroyImmediate(gameObject);
        }
    }
}
