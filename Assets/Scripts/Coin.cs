using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
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
