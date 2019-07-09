using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repeating : MonoBehaviour
{
    BoxCollider2D boxCollider;
    float verticalLength;
    float horizontalOffset;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        verticalLength = boxCollider.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -verticalLength)
        {
            RepositionBackground();
        }
    }

    void RepositionBackground()
    {
        horizontalOffset = Random.Range(-10.0f, 10.0f);

        Vector2 groundOffset = new Vector2(horizontalOffset, verticalLength * 2f);
        transform.position = (Vector2) transform.position + groundOffset;
    }
}
