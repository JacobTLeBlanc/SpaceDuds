using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float moveSpeed = -1.0f;
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

        horizontal = moveSpeed * 2.5f;
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
            xTimer = xLength * 2;
            horizontal *= -1.0f;
        }

        if (yTimer < 0)
        {
            yTimer = yLength * 2;
            vertical *= -1.0f;
        }

        Vector3 move = new Vector3(horizontal, vertical, 0);
        Vector3 position = rb2d.position;
        position = position + move * Time.deltaTime;
        rb2d.position = position;
    }
}
