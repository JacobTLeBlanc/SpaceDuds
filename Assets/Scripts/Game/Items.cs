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

        items[index].active = true;
    }

    public void changeIndex(int direction)
    {
        items[index].active = false;

        index += direction;
        
        if (index < 0)
        {
            index = items.Length - 1;
        }
        else if (index == items.Length)
        {
            index = 0;
        }

        items[index].active = true;

        if (isSpaceships)
        {
            accept.currentSpaceship = items[index];
        }
        else
        {
            accept.currentProjectile = items[index];
        }
    }
}