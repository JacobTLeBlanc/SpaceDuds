using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedAsteroid : MonoBehaviour
{
    Vector2 vel; // Vector to hold velocity
    Rigidbody2D rb2d; 
    float rotationSpeed; // Float to hold rotation speed

    // Start is called before the first frame update
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>(); // Get RigidBody2D component
        this.GetComponent<ScrollingObject>().enabled = false; // Disable scrolling

        vel = GameControl.instance.VectorRand(); // Get Random Vector
        rb2d.velocity = vel; // Set velocity to random vector

        rotationSpeed = Random.Range(-3.0f, 3.0f); // Randomize rotation speed
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed); // Rotate every frame
    }

    // Destroy object on collision
    void OnCollisionEnter2D()
    {
        Destroy(gameObject);
    }
}
