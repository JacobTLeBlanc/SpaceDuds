using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static GameControl instance; // This instance
    public float scrollSpeed = -2.0f; // Scroll Speed

    // Asteroid Clusters
    public GameObject[] asteroids = new GameObject[1];
    public float asteroidTimerLength = 2.0f;
    float timerAsteroid;

    // Score
    public Text scoreText;
    private int score = 0;
    float scoreTimerLength = 0.5f;
    float scoreTimer;

    // Coins
    public GameObject coinPrefab;
    public Text coinAmount;
    private int coins = 0;

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
        scoreTimer = scoreTimerLength;      
        timerAsteroid = asteroidTimerLength;  
    }

    // Update is called once per frame
    void Update()
    {
        // Update timer
        scoreTimer -= Time.deltaTime;
        timerAsteroid -= Time.deltaTime;

        // Add score
        if (scoreTimer < 0)
        {
            score++;
            scoreText.text = score.ToString();
            scoreTimer = scoreTimerLength;
        }

        if (timerAsteroid < 0)
        {
            SpawnAsteroid();
            timerAsteroid = asteroidTimerLength;
        }
    }

    // Spawn asteroid
    void SpawnAsteroid()
    {
        int randAsteroid = 0; // Pick asteroid

        // Create new game object with random X pos
        Vector2 position = new Vector2(0, 8);
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

    public void spawnCoin(int chance, Vector3 position)
    {
        int randInt = Random.Range(0, chance);
        if (randInt == 0)
        {
            Instantiate(coinPrefab, position, Quaternion.identity);
        }
    }

    public void addCoin()
    {
        coins++;
        coinAmount.text = coins.ToString();
    }
}
