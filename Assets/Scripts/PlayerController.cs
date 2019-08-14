using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.1f; // Player speed

    public GameObject bulletPrefab; // Bullet Prefab
    Rigidbody2D rb2d; 
    float horizontal; 
    float vertical;

    // Health
    int currentHealth;
    public int health { get { return currentHealth; } }
    int maxHealth = 3;

    // Invicible
    bool isInvicible;
    public float timeInvicible = 2.0f;
    float invicibleTimer;
    float invicibilityFlashTimer;
    float flashLength = 0.1f;
    bool spriteRender = true;
    
    // Bullet Delay
    bool bulletShot;
    public float timeBullet = 0.5f;
    float bulletTimer;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); // Get RigidBody component

        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        // Get input from gyroscope
        horizontal = Input.acceleration.x;

        // Test on computer
        // horizontal = Input.GetAxis("Horizontal");
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     Fire();
        // }

        // Check if screen is touched is pressed then fire
        for (int i = 0; i < Input.touchCount; i++)
        {
            if(Input.GetTouch(i).phase == TouchPhase.Began)
            {
                Fire();
            }
        }

        // Invicible timer when hit
        if (isInvicible)
        {
            invicibilityFlashTimer -= Time.deltaTime;
            invicibleTimer -= Time.deltaTime;

            if (invicibleTimer < 0)
            {
                isInvicible = false;
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }

            if (invicibilityFlashTimer < 0)
            {
                if (spriteRender)
                {
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    spriteRender = false;
                } 
                else
                {
                    gameObject.GetComponent<SpriteRenderer>().enabled = true;
                    spriteRender = true;
                }
                invicibilityFlashTimer = flashLength;
            }
        }

        // Bullet delay
        if (bulletShot)
        {
            bulletTimer -= Time.deltaTime;
            if (bulletTimer < 0)
            {
                bulletShot = false;
            }

            UIBullet.instance.SetValue((timeBullet - bulletTimer) * 1.0f/timeBullet);
        }
    }

    // Used Fixed Update to smooth movement
    void FixedUpdate() 
    {
        // Use input to change position 
        Vector2 move = new Vector2(horizontal, 0);
        Vector2 position = rb2d.position;
        position = position + move * speed * Time.deltaTime;
        rb2d.position = position;
    }

    // Fire method
    void Fire()
    {
        if (bulletShot) {
            return;
        } 

        // Create bullet object
        GameObject bulletObject = Instantiate(bulletPrefab, rb2d.position + Vector2.up * 0.5f, Quaternion.identity);
        Vector2 direction = new Vector2(0, 1);

        // Call launch method on bullet
        Projectile projectile = bulletObject.GetComponent<Projectile>();
        projectile.Launch(direction, 300.0f);

        // Activate bullet delay
        bulletShot = true;
        bulletTimer = timeBullet;
    }

    // Change health 
    public void ChangeHealth(int amount)
    {
        // If removing health, activate invicibilty
        if (amount < 0)
        {
            if (isInvicible)
            {
                return;
            }

            isInvicible = true;
            invicibleTimer = timeInvicible;
            invicibilityFlashTimer = flashLength;
        }

        // Update health accordingly
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        UIHealth.instance.updateHearts(currentHealth);
    }
}
