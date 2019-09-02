using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public int shopIndex;
    public int price;
    bool isSold;
    public bool isSpaceship;
    public Text priceText;
    public GameObject coinImage;


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

        if (isSold)
        {
            priceText.text = "SOLD";
            coinImage.active = false;
        }
    }

    public bool buy()
    {
        if (isSold)
        {
            return true;
        }

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
