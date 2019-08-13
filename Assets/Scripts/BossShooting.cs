using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooting : MonoBehaviour
{
    public GameObject bossBullet;
    public float force;
    public float timerLength = 0.1f;
    float timer;
    Rigidbody2D rb2d;
    Rigidbody2D rb2dBullet;
    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        timer = timerLength;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            switch(count % 3)
            {
                case 0:
                    firstAttack();
                    break;
                case 1:
                    secondAttack();
                    break;
                case 2:
                    thirdAttack();
                    break;
            }

            count++;
            timer = timerLength;
        }
    }

    void Fire(Vector2 direction, float force, float rotationZ)
    {
        GameObject bullet = Instantiate(bossBullet, rb2d.position + Vector2.down * 2.3f, Quaternion.identity);
        rb2dBullet = bullet.GetComponent<Rigidbody2D>();
        bullet.transform.Rotate(0, 0, rotationZ);
        rb2dBullet.AddForce(direction * force);
    }

    void firstAttack()
    {
        Vector2 direction = new Vector2 (0.5f, -0.5f);
        float rotZ = 45.0f;

        for (int i = 0; i < 5; i++) 
        {
            Fire(direction, force, rotZ);
            direction.x -= 0.1f;
            direction.y -= 0.1f;
            rotZ -= 9.0f;    
        }
    }

    void secondAttack()
    {
        Vector2 direction = new Vector2 (-0.5f, -0.5f);
        float rotZ = -45.0f;

        for (int i = 0; i < 5; i++) 
        {
            Fire(direction, force, rotZ);
            direction.x += 0.1f;
            direction.y -= 0.1f;
            rotZ += 9.0f;    
        }
    }

    void thirdAttack()
    {
        Vector2 direction = new Vector2 (-0.5f, -0.5f);
        float rotZ = -45.0f;

        for (int i = 0; i < 2; i++)
        {
            Fire(direction, force, rotZ);
            direction.x += 0.25f;
            direction.y -= 0.25f;
            rotZ += 22.5f;
        }

        direction = new Vector2(0.5f, -0.5f);
        rotZ = 45.0f;

        for (int i = 0; i < 2; i++)
        {
            Fire(direction, force, rotZ);
            direction.x -= 0.25f;
            direction.y -= 0.25f;
            rotZ -= 22.5f;
        }
    }
}
