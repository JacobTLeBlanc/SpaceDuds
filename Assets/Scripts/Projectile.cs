using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rb2d;
    

    // Start is called before the first frame update
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>(); // Get RigidBody component
    }

    // Update is called once per frame
    void Update()
    {
        // If distance greater than 10 units destroy bullet
        if (transform.position.magnitude > 20.0f)
        {
            Destroy(gameObject);
        }
    }

    // Launch method
    public void Launch(Vector2 direction, float force)
    {
        rb2d.AddForce(direction * force); // Add force to bullet
    }

    // Destroy Projectile on collison
    void OnCollisionEnter2D()
    {
        Destroy(gameObject);
    }
}
