using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    float yTimer;
    float xTimer;
    public float xLength;
    public float yLength;
    float horizontal;
    float vertical;

    Rigidbody2D rb2d;


    // Start is called before the first frame update
    void Awake()
    {
        xTimer = xLength;
        yTimer = yLength;

        horizontal = moveSpeed;
        vertical = moveSpeed;

        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        xTimer -= Time.deltaTime;
        yTimer -= Time.deltaTime;

        if (xTimer < 0)
        {
            xTimer = xLength;
            horizontal *= -1;
        }

        if (yTimer < 0)
        {
            yTimer = yLength;
            vertical *= -1;
        }

    }

    void FixedUpdate()
    {
        Vector2 move = new Vector2(horizontal, vertical);
        Vector2 position = rb2d.position;
        position = position + move * Time.deltaTime;
        rb2d.position = position;
    }
}
