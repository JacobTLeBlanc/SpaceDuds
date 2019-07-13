using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); // Get RigidBogy component

        // Scroll down as scroll speed (from GameControl)
        rb2d.velocity = new Vector2(0, GameControl.instance.scrollSpeed);
    }
}
