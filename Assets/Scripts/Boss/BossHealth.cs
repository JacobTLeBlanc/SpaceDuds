using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{

    int health = 10;

    bool isHit;
    float hitTimer;
    float hitLength = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        hitTimer = hitLength;
    }

    // Update is called once per frame
    void Update()
    {
        if (isHit)
        {
            hitTimer -= Time.deltaTime;
            this.GetComponent<SpriteRenderer>().color = Color.red;

            if (hitTimer < 0)
            {
                isHit = false;
                hitTimer = hitLength;
                this.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Projectile bullet = other.gameObject.GetComponent<Projectile>();

        if (bullet != null)
        {
            health--;
            isHit = true;

            if (health == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
