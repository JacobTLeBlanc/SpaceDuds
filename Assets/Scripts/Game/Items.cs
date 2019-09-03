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
        // If spaceships
        if (isSpaceships)
        {
            index = SaveLoad.data.currentPlayer; // Get Current Spaceship
            accept.currentSpaceship = items[index]; // Set Current Spaceship
        }
        else
        {
            index = SaveLoad.data.currentProjectile; // Get Current Projectile
            accept.currentProjectile = items[index]; // Set Current Projectile
        }

        items[index].active = true; // Show items
    }

    public void changeIndex(int direction)
    {
        items[index].active = false; // Hide last item

        index += direction; // Add 1 or -1
        
        // If -1, cycle to end of list
        if (index < 0) 
        {
            index = items.Length - 1;
        }
        else if (index == items.Length) // If at end, cycle to front
        {
            index = 0;
        }

        items[index].active = true; // Show new items

        // Set new items
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