using System.Collections;
using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class GameData
{
    // Data
    public int totalCoins; // Coins
    public int highscore; // Highscore
    public int currentPlayer; // Current Spaceship
    public int currentProjectile; // Current Projectile
    public bool[] spaceships = { true, false, false, false, false, false }; // Spaceships bought
    public bool[] projectiles = { true, false, false, false, false, false }; // Projectiles bought
    public bool musicOn = true;


    public GameData()
    {
        // Set all data to initial values
        totalCoins = 0;
        highscore = 0;
        currentPlayer = 0;
        currentProjectile = 0;
    }
}
