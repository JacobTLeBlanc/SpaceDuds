using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    Rigidbody2D rb2d;

    public float timerLength = 5.0f;
    float destroyTimer = 0.0f;
    

    // Start is called before the first frame update
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        destroyTimer = timerLength;
    }

    // Update is called once per frame
    void Update()
    {
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
        DestroyedAsteroid destroyed = gameObject.GetComponent<DestroyedAsteroid>();

        if (bullet != null && destroyed == null)
        {
            int Rand = Random.Range(1, 3);

            for (int i = 0; i < Rand; i++)
            {
                breakAsteroid();
            }
            Destroy(gameObject);
        }
    }

    void breakAsteroid()
    {
        // Create new asteroid
        GameObject newAst = Instantiate(gameObject, this.transform.position, Quaternion.identity);
        newAst.transform.localScale = this.transform.localScale * Random.Range(0.3f, 0.8f);
        newAst.AddComponent<DestroyedAsteroid>();
    }

    

}
