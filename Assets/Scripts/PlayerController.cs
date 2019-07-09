using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;

    public GameObject bulletPrefab;
    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 move = new Vector2(horizontal, vertical);

        Vector2 position = rb2d.position;
        position = position + move * speed * Time.deltaTime;
        rb2d.position = position;

        if (Input.GetKeyDown(KeyCode.C))
        {
            Fire();
        }
    }

    void Fire()
    {
        GameObject bulletObject = Instantiate(bulletPrefab, rb2d.position + Vector2.up * 0.5f, Quaternion.identity);
        Vector2 direction = new Vector2(0, 1);

        Projectile projectile = bulletObject.GetComponent<Projectile>();
        projectile.Launch(direction, 300.0f);
    }

}
