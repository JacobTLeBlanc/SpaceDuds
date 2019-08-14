using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
{
    float destroyTimer;
    float destroyLength = 10.0f;

    void Start()
    {
        destroyTimer = destroyLength;
    }

    void Update()
    {
        destroyTimer -= Time.deltaTime;

        if (destroyTimer < 0)
        {
            Destroy(gameObject);
        }
    }
}
