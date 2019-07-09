using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    Rigidbody2D rb2d;

    public float scrollingSpeed = -3.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        rb2d.velocity = new Vector2(0, scrollingSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
