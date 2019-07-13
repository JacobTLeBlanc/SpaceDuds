using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static GameControl instance; // This instance
    public float scrollSpeed = -3.0f; // Scroll Speed
    float asteroidTimer;
    public float timerLength = 0.5f;

    // Asteroids
    public GameObject brownAsteroid;
    public GameObject greySmallAsteroid;
    public GameObject greyBigAsteroid;
    public GameObject lightGreyAsteroid;
    public GameObject[] asteroids = new GameObject[4];

    // Start is called before the first frame update
    void Awake()
    {
        // Make sure there is only one instance of game control
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }

        // Start timer
        asteroidTimer = timerLength;

        asteroids[0] = brownAsteroid;
        asteroids[1] = greySmallAsteroid;
        asteroids[2] = greyBigAsteroid;
        asteroids[3] = lightGreyAsteroid;
    }

    // Update is called once per frame
    void Update()
    {
        asteroidTimer -= Time.deltaTime;

        if (asteroidTimer < 0)
        {
            spawnAsteroid();
            asteroidTimer = timerLength;
        }
    }

    void spawnAsteroid()
    {
        int randAsteroid = Random.Range(0, 3);
        float randXPos = Random.Range(-15.0f, 15.0f);

        Vector2 position = new Vector2(randXPos, 10);
        Instantiate(asteroids[randAsteroid], position, Quaternion.identity);
    }
}
