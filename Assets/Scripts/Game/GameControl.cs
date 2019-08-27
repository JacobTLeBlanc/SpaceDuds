using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static GameControl instance; // This instance
    public float scrollSpeed = -2.0f; // Scroll Speed

    // Asteroid Clusters
    public GameObject[] asteroids = new GameObject[5];
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

    // Heart PowerUp
    public GameObject heartPrefab;

    // Triple Shot
    public GameObject triplePrefab;

    // Infinity PowerUp
    public GameObject infinityPrefab;

    // GameOver
    public GameObject controlsUI;
    public GameObject gameOverUI;
    public GameObject healthUI;
    public GameObject bulletUI;
    public bool gameOver;

    // Boss
    public GameObject[] bosses;
    int currentBoss = 0;
    public bool bossBattle = false;
    public bool bossSpawn = false;
    float bossDelay;
    Quaternion rotateZ = new Quaternion(0, 0, -180, 0);

    // Difficulty
    public float difficultyScale = 1.0f;

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
        bossDelay = asteroidTimerLength;
    }

    // Update is called once per frame
    void Update()
    {
        // Update timer
        scoreTimer -= Time.deltaTime;
        timerAsteroid -= Time.deltaTime;

        // Add score
        if (scoreTimer < 0 && !bossBattle && !gameOver)
        {
            score++;
            scoreText.text = score.ToString();
            scoreTimer = scoreTimerLength;
        }

        // Timer for asteroid clusters spawns
        if (timerAsteroid < 0 && !bossBattle && !gameOver)
        {
            SpawnAsteroid();
            timerAsteroid = asteroidTimerLength;
        }

        // Check if score is divisible by 100
        if (score % 100 == 0 && score != 0)
        {
            bossBattle = true;
        }

        // Spawn boss after delay
        if (bossBattle)
        {
            bossDelay -= Time.deltaTime;

            if (bossDelay < 0 && !bossSpawn)
            {
                scrollSpeed = 0.0f;
                Instantiate(bosses[currentBoss % bosses.Length], gameObject.transform.position + Vector3.up * 4, rotateZ);
                bossSpawn = true;
                currentBoss++;
            }
        }

        if (gameOver)
        {
            controlsUI.active = false;
            gameOverUI.active = true;
            bulletUI.active = false;
            healthUI.active = false;
            scrollSpeed = 0.0f;
        }
    }

    // Spawn asteroid
    void SpawnAsteroid()
    {

        // Randomize if flipped or not
        int isFlipped = Random.Range(0, 2);
        int rotation = 0;

        if (isFlipped == 0) 
        {
            rotation = 180;
        }

        Quaternion quatRotation = new Quaternion(0, rotation, 0 , 0);

        int randAsteroid = Random.Range(0, asteroids.Length); // Pick asteroid

        // Create new game object with random X pos
        Vector2 position = new Vector2(0, 8);
        Instantiate(asteroids[randAsteroid], position, quatRotation);
    }

    // Generate Random Vector2
    public Vector2 VectorRand()
    {
        float x = Random.Range(-3.0f, 3.0f);
        float y = Random.Range(-1.0f, -4.0f);
        Vector2 vector = new Vector2(x, y);

        return vector;
    }

    // Spawn a coin with a given chance
    public void spawnCoin(int chance, Vector3 position)
    {
        int randInt = Random.Range(0, chance);
        if (randInt == 0)
        {
            Instantiate(coinPrefab, position, Quaternion.identity);
        }
    }

    // Add coin to counter
    public void addCoin()
    {
        coins++;
        coinAmount.text = coins.ToString();
    }

    public void spawnPowerUp(int chance, Vector3 position)
    {
        int randInt = Random.Range(0, chance);

        if (randInt == 0)
        {
            Instantiate(heartPrefab, position, Quaternion.identity);
        }

        if (randInt == 1)
        {
            Instantiate(triplePrefab, position, Quaternion.identity);
        }

        if (randInt == 2)
        {
            Instantiate(infinityPrefab, position, Quaternion.identity);
        }
    }
}
