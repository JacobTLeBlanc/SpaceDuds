using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repeating : MonoBehaviour
{
    BoxCollider2D boxCollider;
    float verticalLength;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>(); // Get BoxCollider component
        verticalLength = boxCollider.size.y; // Get vertical length
    }

    // Update is called once per frame
    void Update()
    {
        // If the object moves passed its vertical length, reposition
        if (transform.position.y < -verticalLength)
        {
            RepositionBackground();
        }
    }

    // RepositionBackground method
    void RepositionBackground()
    {
        // Move object twice as high (create infinite illusion)
        Vector2 offset = new Vector2(0, verticalLength * 2f);
        transform.position = (Vector2) transform.position + offset;
    }
}
