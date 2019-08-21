using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooting : MonoBehaviour
{
    // Bullet used by boss
    public GameObject bossBullet;

    // force of bullet
    public float force;

    // Timer between attacks
    public float timerLength = 0.1f;
    float timer;

    // Rigidbody components
    Rigidbody2D rb2d;
    Rigidbody2D rb2dBullet;

    // Count for attack cycle
    int count = 0;

    // Distance(y) from boss' centre to spawn bullet
    public float distance;

    // Which attack cycle to use
    public int bossAttackCycle;

    // Start is called before the first frame update
    void Start()
    {
        // Get rigidbody component of boss
        rb2d = GetComponent<Rigidbody2D>();

        // Start timer
        timer = timerLength;

        // Difficulty scale
        force *= (GameControl.instance.difficultyScale / 100) + 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Update timer
        timer -= Time.deltaTime;

        // If timer is done, start next attack
        if (timer < 0)
        {
            // Cycle through attacks
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
            } 
            else if (bossAttackCycle == 1)
            {
                ufoAttack(count);
            }
            else if (bossAttackCycle == 2) 
            {
                smallBossAttack(count);
            }

            // Update count and timer
            count++;
            timer = timerLength;
        }
    }

    void Fire(Vector2 direction, float force, float rotationZ)
    {
        // Spawn bullet
        GameObject bullet = Instantiate(bossBullet, rb2d.position + Vector2.down * distance, Quaternion.identity);
        
        // Get rigidbody component
        rb2dBullet = bullet.GetComponent<Rigidbody2D>();

        // Rotate accordingly
        bullet.transform.Rotate(0, 0, rotationZ);

        // Add force to bullet
        rb2dBullet.AddForce(direction * force);
    }

    // First attack for first cycle
    void firstAttack()
    {
        // Initial direction of bullet
        Vector2 direction = new Vector2 (0.5f, -0.5f);

        // Initial rotation of bullet
        float rotZ = 45.0f;

        // Fire bullets to right
        for (int i = 0; i < 5; i++) 
        {
            Fire(direction, force, rotZ);
            direction.x -= 0.1f;
            direction.y -= 0.1f;
            rotZ -= 9.0f;    
        }
    }

    // Second attack of first cycle
    void secondAttack()
    {
        // Init direction of bullet
        Vector2 direction = new Vector2 (-0.5f, -0.5f);

        // Init rotation of bullet
        float rotZ = -45.0f;

        // Fire bullets to left
        for (int i = 0; i < 5; i++) 
        {
            Fire(direction, force, rotZ);
            direction.x += 0.1f;
            direction.y -= 0.1f;
            rotZ += 9.0f;    
        }
    }

    // Third attack of first cycle
    void thirdAttack()
    {
        // Init direction of bullet
        Vector2 direction = new Vector2 (-0.5f, -0.5f);

        // Init rotation of bullet
        float rotZ = -45.0f;

        // Fire bullets to left
        for (int i = 0; i < 2; i++)
        {
            Fire(direction, force, rotZ);
            direction.x += 0.25f;
            direction.y -= 0.25f;
            rotZ += 22.5f;
        }

        // Change direction and rotation to right
        direction = new Vector2(0.5f, -0.5f);
        rotZ = 45.0f;

        // Fire bullets to right
        for (int i = 0; i < 2; i++)
        {
            Fire(direction, force, rotZ);
            direction.x -= 0.25f;
            direction.y -= 0.25f;
            rotZ -= 22.5f;
        }
    }

    // Ufo attack cycle
    void ufoAttack(int count)
    {
        // Direction and rotation
        Vector2 direction;
        float rotZ;

        switch(count % 3)
        {
            // If first attack
            case 0:

                // direction and rotation of bullet
                direction = new Vector2(0, -1);
                rotZ = 0.0f;

                // Fire bullet
                Fire(direction, force, rotZ);
                break;

            // second attack
            case 1:

                // Direction and rotation of bullet
                direction = new Vector2(0.25f, -1f);
                rotZ = 22.5f;

                // Fire bullet
                Fire(direction, force, rotZ);
                break;

            // third attack
            case 2:

                // Directiona and rotation of bullet 
                direction = new Vector2(-0.25f, -1f);
                rotZ = -22.5f;

                // Fire bullet
                Fire(direction, force, rotZ);
                break;
        }
    }

    // Small boss attack
    void smallBossAttack(int count)
    {
        // Direction and rotation
        Vector2 direction;
        float rotZ;

        // Cycle through all attacks
        switch(count % 9)
        {
            case 0:
            case 8:
                direction = new Vector2(0.5f, -1f);
                rotZ = 45.0f;
                Fire(direction, force, rotZ);
                break;

            case 1:
            case 7:
                direction = new Vector2(0.25f, -1f);
                rotZ = 22.5f;
                Fire(direction, force, rotZ);
                break;

            case 2:
            case 6:
                direction = new Vector2(0.25f, -1f);
                rotZ = 22.5f;
                Fire(direction, force, rotZ);

                direction.x = -direction.x;
                rotZ = -rotZ;
                Fire(direction, force, rotZ);
                break;
            
            case 3:
            case 5:
                direction = new Vector2(-0.25f, -1f);
                rotZ = -22.5f;
                Fire(direction, force, rotZ);
                break;

            case 4:
                direction = new Vector2(-0.5f, -1f);
                rotZ = -45.0f;
                Fire(direction, force, rotZ);
                break;
        }
    }
}
