using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static GameControl instance; // This instance
    public float scrollSpeed = -3.0f; // Scroll Speed
    float asteroidTimer;
    public float timerLength = 3.0f;

    // Asteroids
    public GameObject brownAsteroid;
    public GameObject greySmallAsteroid;
    public GameObject greyBigAsteroid;
    public GameObject lightGreyAsteroid;

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
        
    }
}
