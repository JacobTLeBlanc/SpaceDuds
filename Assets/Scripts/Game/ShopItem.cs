﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    public int shopIndex;
    public int price;
    bool isSold;
    public bool isSpaceship;

    private void Start()
    {
        if (isSpaceship)
        {
            isSold = SaveLoad.data.spaceships[shopIndex];
        }
        else
        {
            isSold = SaveLoad.data.projectiles[shopIndex];
        }
    }

    public bool buy()
    {
        if (isSold)
        {
            return true;
        }

        if (SaveLoad.data.totalCoins > price)
        {
            SaveLoad.data.totalCoins -= price;
            isSold = true;
            return true;
        }

        return false;
    }
}