using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public int shopIndex; // Index of Item Shop
    public int price; // Price
    bool isSold; // If sold
    public bool isSpaceship; // If spaceship
    public Text priceText; // Price Text UI
    public GameObject coinImage; // Coin Image


    private void Start()
    {
        // If spaceship
        if (isSpaceship)
        {
            isSold = SaveLoad.data.spaceships[shopIndex]; // Get Data
        }
        else
        {
            isSold = SaveLoad.data.projectiles[shopIndex]; // Get Data
        }

        // If sold, show on UI
        if (isSold)
        {
            priceText.text = "SOLD";
            coinImage.active = false;
        }
    }

    // buy
    public bool buy()
    {
        // If sold exit method
        if (isSold)
        {
            return true;
        }

        // If enough coins, remove coins and buy item
        if (SaveLoad.data.totalCoins >= price)
        {
            SaveLoad.data.totalCoins -= price;
            isSold = true;

            if (isSpaceship)
            {
                SaveLoad.data.spaceships[shopIndex] = true;
            }
            else
            {
                SaveLoad.data.projectiles[shopIndex] = true;
            }

            return true;
        }

        return false;
    }
}
