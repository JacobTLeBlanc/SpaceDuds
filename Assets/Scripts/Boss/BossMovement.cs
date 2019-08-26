using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    // Speed of boss
    public float moveSpeed = -1.0f;

    // Movement timers
    float yTimer;
    float xTimer;
    public float xLength;
    public float yLength;

    // Position
    float horizontal;
    float vertical;

    // Riigidody component
    Rigidbody2D rb2d;


    // Start is called before the first frame update
    void Awake()
    {
        // Start timers
        xTimer = xLength;
        yTimer = yLength;

        // Set positions to move speed
        horizontal = moveSpeed * 2.5f;
        vertical = moveSpeed;

        // Get rigidbody2d component
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Update timers
        xTimer -= Time.deltaTime;
        yTimer -= Time.deltaTime;

        // Change horizontal direction when timer ends
        if (xTimer < 0)
        {
            xTimer = xLength * 2;
            horizontal *= -1.0f;
        }

        // Change vertical direction when timer ends
        if (yTimer < 0)
        {
            yTimer = yLength * 2;
            vertical *= -1.0f;
        }

        // Update position
        Vector3 move = new Vector3(horizontal, vertical, 0);
        Vector3 position = rb2d.position;
        position = position + move * Time.deltaTime;
        rb2d.position = position;
    }
}
