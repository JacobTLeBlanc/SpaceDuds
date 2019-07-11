using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.1f;

    public GameObject bulletPrefab;
    Rigidbody2D rb2d;
    float horizontal;
    float vertical;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        

        if (Input.GetKeyDown(KeyCode.C))
        {
            Fire();
        }
    }

    void FixedUpdate() 
    {
        Vector2 move = new Vector2(horizontal, vertical);
        Vector2 position = rb2d.position;
        position = position + move * speed * Time.deltaTime;
        rb2d.position = position;
    }

    void Fire()
    {
        GameObject bulletObject = Instantiate(bulletPrefab, rb2d.position + Vector2.up * 0.5f, Quaternion.identity);
        Vector2 direction = new Vector2(0, 1);

        Projectile projectile = bulletObject.GetComponent<Projectile>();
        projectile.Launch(direction, 300.0f);
    }

}
