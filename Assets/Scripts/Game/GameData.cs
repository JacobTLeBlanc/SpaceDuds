using System.Collections;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int totalCoins;
    public int highscore;
    public int currentPlayer;
    public int currentProjectile;


    public GameData()
    {
        totalCoins = 0;
        highscore = 0;
        currentPlayer = 0;
        currentProjectile = 0;
    }
}
