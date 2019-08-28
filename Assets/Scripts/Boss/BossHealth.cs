using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    // Health
    int health = 5 * ((int) GameControl.instance.difficultyScale);

    // When boss is hit
    bool isHit;
    float hitTimer;
    float hitLength = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        // Start timer
        hitTimer = hitLength;
    }

    // Update is called once per frame
    void Update()
    {
        // When hit flash red
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
        // Get bullet
        Projectile bullet = other.gameObject.GetComponent<Projectile>();

        // When hit by bullet reduce health and flash red
        if (bullet != null)
        {
            health--;
            isHit = true;

            // If dead, continue game and destroy boss
            if (health == 0)
            {
                GameControl.instance.bossBattle = false;
                GameControl.instance.bossSpawn = false;
                GameControl.instance.difficultyScale += 1.0f;
                GameControl.instance.scrollSpeed = -3.0f + ((1 / GameControl.instance.difficultyScale));
                Destroy(gameObject);
            }
        }
    }
}
