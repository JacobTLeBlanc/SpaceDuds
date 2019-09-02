using System.Collections;
using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class GameData
{
    public int totalCoins;
    public int highscore;
    public int currentPlayer;
    public int currentProjectile;
    public bool[] spaceships = { true, false, false, false, false, false };
    public bool[] projectiles = { true, false, false, false, false, false };


    public GameData()
    {
        totalCoins = 0;
        highscore = 0;
        currentPlayer = 0;
        currentProjectile = 0;
    }

}
