using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Items : MonoBehaviour
{
    public ShopAccept accept;
    public GameObject[] items;
    public bool isSpaceships;
    int index;

    // Start is called before the first frame update
    void Start()
    {
        if (isSpaceships)
        {
            index = SaveLoad.data.currentPlayer;
            accept.currentSpaceship = items[index];
        }
        else
        {
            index = SaveLoad.data.currentProjectile;
            accept.currentProjectile = items[index];
        }

    }

    public void changeIndex(int direction)
    {
        items[index].active = false;

        index += direction;
        index = Math.Abs(index % items.Length);

        items[index].active = true;

        if (isSpaceships)
        {
            accept.currentSpaceship = items[index];
        } else
        {
            accept.currentProjectile = items[index];
        }
    }
}