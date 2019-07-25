using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static GameControl instance; // This instance
    public float scrollSpeed = -3.0f; // Scroll Speed
    float asteroidTimer; // Spawn timer of asteroid
    public float timerLength = 0.5f; // Length of spawn timer

    // Asteroids to spawn
    public GameObject brownAsteroid;
    public GameObject greySmallAsteroid;
    public GameObject greyBigAsteroid;
    public GameObject lightGreyAsteroid;
    public GameObject[] asteroids = new GameObject[4];
    public Text scoreText;
    private int score = 0;
    float scoreTimerLength = 0.5f;
    float scoreTimer;

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
        scoreTimer = scoreTimerLength;        

        // Add asteroids to array 
        asteroids[0] = brownAsteroid;
        asteroids[1] = greySmallAsteroid;
        asteroids[2] = greyBigAsteroid;
        asteroids[3] = lightGreyAsteroid;
    }

    // Update is called once per frame
    void Update()
    {
        // Update timer
        asteroidTimer -= Time.deltaTime;
        scoreTimer -= Time.deltaTime;

        // Spawn asteroid when timer ends
        if (asteroidTimer < 0)
        {
            SpawnAsteroid();
            asteroidTimer = timerLength;
        }

        if (scoreTimer < 0)
        {
            score++;
            scoreText.text = score.ToString();
        }
    }

    // Spawn asteroid
    void SpawnAsteroid()
    {
        int randAsteroid = Random.Range(0, 4); // Pick asteroid
        float randXPos = Random.Range(-15.0f, 15.0f); // Pick pos

        // Create new game object with random X pos
        Vector2 position = new Vector2(randXPos, 10);
        Instantiate(asteroids[randAsteroid], position, Quaternion.identity);
    }

    // Generate Random Vector2
    public Vector2 VectorRand()
    {
        float x = Random.Range(-3.0f, 3.0f);
        float y = Random.Range(-1.0f, -4.0f);
        Vector2 vector = new Vector2(x, y);

        return vector;
    }
}
