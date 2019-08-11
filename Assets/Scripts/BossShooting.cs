using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooting : MonoBehaviour
{
    public GameObject bossBullet;
    public float force;
    bool timerOn;
    float timerLength = 0.1f;
    float timer;
    Rigidbody2D rb2d;
    Rigidbody2D rb2dBullet;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        firstAttack();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Fire(Vector2 direction, float force)
    {
        GameObject bullet = Instantiate(bossBullet, rb2d.position + Vector2.down * 2.3f, Quaternion.identity);
        rb2dBullet = bullet.GetComponent<Rigidbody2D>();
        rb2dBullet.AddForce(direction * force);
    }

    void firstAttack()
    {
        Vector2 direction = new Vector2 (0, -1);
        Fire(direction, force);
    }
}
