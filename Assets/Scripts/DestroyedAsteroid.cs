using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedAsteroid : MonoBehaviour
{
    Vector2 vel;
    Rigidbody2D rb2d;
    float rotationSpeed;

    // Start is called before the first frame update
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        this.GetComponent<ScrollingObject>().enabled = false;

        vel = GameControl.instance.VectorRand();
        rb2d.velocity = vel;

        rotationSpeed = Random.Range(-3.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed);
    }

}
