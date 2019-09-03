﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.1f; // Player speed
    public float distance; // Distance from center to shoot projectile

    public GameObject bulletPrefab; // Bullet Prefab
    Rigidbody2D rb2d; 
    float horizontal; 

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

    // Triple Shot
    public bool tripleShot = false;
    public float tripleShotTimer;

    // Infinite Shot
    public bool infiniteShot = false;
    public float infiniteShotTimer;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); // Get RigidBody component

        currentHealth = maxHealth; // Health
    }

    // Update is called once per frame
    void Update()
    {
        // Buttonm Input
        horizontal = CrossPlatformInputManager.GetAxis("Horizontal");

        // Test on Computer
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     if (tripleShot)
        //     {
        //         TripleFire();
        //     }
        // 
        //     Fire();
        // }

        // Check if screen is touched is pressed then fire
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.GetTouch(i).position.x >= Screen.width / 2)
            {
                if (tripleShot)
                {
                    TripleFire();
                }

                Fire();
            }
        }

        // Invicible timer when hit
        if (isInvicible)
        {
            invicibilityFlashTimer -= Time.deltaTime;
            invicibleTimer -= Time.deltaTime;

            // Flash for invicibilty
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

            if (invicibleTimer < 0)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
                isInvicible = false;
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

        // Triple Shot Timer
        if (tripleShot)
        {
            tripleShotTimer -= Time.deltaTime;

            if (tripleShotTimer < 0)
            {
                tripleShot = false;
            }
        }

        // Infinite Shot Timer
        if (infiniteShot)
        {
            infiniteShotTimer -= Time.deltaTime;

            if (infiniteShotTimer < 0)
            {
                infiniteShot = false;
                timeBullet = 1.5f;
            }
        }
    }

    // Used Fixed Update to smooth movement
    void FixedUpdate() 
    {
        // Use input to change position 
        Vector2 move = new Vector2(horizontal * speed, 0);
        Vector2 position = rb2d.position;
        position = position + move * Time.deltaTime;
        rb2d.position = position;
    }

    // Fire method
    void Fire()
    {
        if (bulletShot) {
            return;
        } 

        // Create bullet object
        GameObject bulletObject = Instantiate(bulletPrefab, rb2d.position + Vector2.up * distance, Quaternion.identity);
        Vector2 direction = new Vector2(0, 1);

        // Call launch method on bullet
        Projectile projectile = bulletObject.GetComponent<Projectile>();
        projectile.Launch(direction, 300.0f);

        // Activate bullet delay
        bulletShot = true;
        bulletTimer = timeBullet;
    }

    // Triple Fire PowerUp
    void TripleFire()
    {
        // if delay is not finished, exit method
        if (bulletShot) {
            return;
        }

        // Spawn bullets
        GameObject bullet1 = Instantiate(bulletPrefab, rb2d.position + Vector2.up * 0.5f, Quaternion.identity);
        GameObject bullet2 = Instantiate(bulletPrefab, rb2d.position + Vector2.up * 0.5f, Quaternion.identity);

        // Right Bullet Launch
        Vector2 direction = new Vector2(0.25f, 1.0f);
        Projectile projectile = bullet1.GetComponent<Projectile>();
        projectile.Launch(direction, 300.0f);

        // Left Bullet Launch
        direction = new Vector2(-0.25f, 1.0f);
        projectile = bullet2.GetComponent<Projectile>();
        projectile.Launch(direction, 300.0f);
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

        // Gameover
        if (health == 0)
        {
            GameControl.instance.gameOver = true;
            GameControl.instance.ShowAd();
        }
    }
}
