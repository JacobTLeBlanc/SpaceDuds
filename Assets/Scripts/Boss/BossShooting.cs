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
    public float distance;
    public int bossAttackCycle;

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
            if (bossAttackCycle == 0)
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
            } else if (bossAttackCycle == 1)
            {
                switch(count % 3)
                {
                    case 0:
                        ufoAttack(count);
                        break;

                    case 1:
                        ufoAttack(count);
                        break;
                    
                    case 2:
                        ufoAttack(count);
                        break;
                }
            }

            count++;
            timer = timerLength;
        }
    }

    void Fire(Vector2 direction, float force, float rotationZ)
    {
        GameObject bullet = Instantiate(bossBullet, rb2d.position + Vector2.down * distance, Quaternion.identity);
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

    void ufoAttack(int count)
    {
        Vector2 direction;
        float rotZ;

        switch(count % 3)
        {
            case 0:
                direction = new Vector2(0, -1);
                rotZ = 0.0f;
                Fire(direction, force, rotZ);
                break;

            case 1:
                direction = new Vector2(0.25f, -1f);
                rotZ = 22.5f;
                Fire(direction, force, rotZ);
                break;

            case 2:
                direction = new Vector2(-0.25f, -1f);
                rotZ = -22.5f;
                Fire(direction, force, rotZ);
                break;
        }
    }
}
