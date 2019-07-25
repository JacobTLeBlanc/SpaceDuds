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

    int currentHealth;
    public int health { get { return currentHealth; } }
    int maxHealth = 3;

    bool isInvicible;
    public float timeInvicible = 2.0f;
    float invicibleTimer;
    

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
        //    Fire();
        // }

        // Check if screen is touched is pressed then fire
        for (int i = 0; i < Input.touchCount; i++)
        {
            if(Input.GetTouch(i).phase == TouchPhase.Began)
            {
                Fire();
            }
        }

        if (isInvicible)
        {
            invicibleTimer -= Time.deltaTime;
            if (invicibleTimer < 0)
            {
                isInvicible = false;
            }
        }
    }

    // Used Fixed Update to smooth movement
    void FixedUpdate() 
    {
        // Use input to change position 
        Vector2 move = new Vector2(horizontal, -3);
        Vector2 position = rb2d.position;
        position = position + move * speed * Time.deltaTime;
        rb2d.position = position;
    }

    // Fire method
    void Fire()
    {
        // Create bullet object
        GameObject bulletObject = Instantiate(bulletPrefab, rb2d.position + Vector2.up * 0.5f, Quaternion.identity);
        Vector2 direction = new Vector2(0, 1);

        // Call launch method on bullet
        Projectile projectile = bulletObject.GetComponent<Projectile>();
        projectile.Launch(direction, 300.0f);
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvicible)
            {
                return;
            }

            isInvicible = true;
            invicibleTimer = timeInvicible;
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
        UIHealth.instance.updateHearts(currentHealth);
    }
}
