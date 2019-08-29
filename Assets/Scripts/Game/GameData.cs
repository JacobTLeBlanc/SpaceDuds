using System.Collections;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int totalCoins;
    public int highscore;


    public GameData()
    {
        totalCoins = 0;
        highscore = 0;
    }
}
