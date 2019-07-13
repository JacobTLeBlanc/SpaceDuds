using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    Rigidbody2D rb2d;

    public float rotationSpeed;
    public float timerLength = 5.0f;
    float destroyTimer = 0.0f;
    

    // Start is called before the first frame update
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rotationSpeed = 0.0f;
        destroyTimer = timerLength;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed);

        destroyTimer -= Time.deltaTime;
        if (destroyTimer < 0)
        {
            Destroy(gameObject);
        }
    }

    // Destroy on collison
    void OnCollisionEnter2D(Collision2D other)
    {
        Projectile bullet = other.gameObject.GetComponent<Projectile>();

        if (bullet != null)
        {
            breakAsteroid(VectorRand());
            breakAsteroid(VectorRand());
            Destroy(gameObject);
        }
    }

    void breakAsteroid(Vector2 vector)
    {
        // Create new asteroid
        GameObject newAst = Instantiate(gameObject, this.transform.position, Quaternion.identity);
        Rigidbody2D rb2d = newAst.GetComponent<Rigidbody2D>();
        newAst.GetComponent<ScrollingObject>().enabled = false;
        rb2d.velocity = vector; 
        newAst.GetComponent<Asteroid>().rotationSpeed = Random.Range(-4.0f, 4.0f);
        newAst.transform.localScale = this.transform.localScale * 0.5f;
    }

    Vector2 VectorRand()
    {
        float x = Random.Range(-3.0f, 3.0f);
        float y = Random.Range(-1.0f, -4.0f);
        Vector2 vector = new Vector2(x, y);

        return vector;
    }

}
