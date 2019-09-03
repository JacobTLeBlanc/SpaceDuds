using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopAccept : MonoBehaviour
{
    public GameObject currentSpaceship; // Current Spaceship
    public GameObject currentProjectile; // Current Projectile

    public GameObject notEnough;
    float timer;
    float timerLength = 0.5f;

    private void Awake()
    {
        SaveLoad.Load(); // Load

        Button btn = this.GetComponent<Button>(); // Button Component
        btn.onClick.AddListener(Accept); // On Click Accept
    }

    private void Update()
    {
        if (notEnough.active)
        {
            timer -= Time.deltaTime;

            if (timer < 0)
            {
                notEnough.active = false;
            }
        }
    }

    void Accept()
    {
        // Get Spaceship
        ShopItem item = currentSpaceship.GetComponent<ShopItem>();

        // Check if it can be bought/is already sold
        if (item.buy())
        {
            SaveLoad.data.currentPlayer = item.shopIndex;
        } 
        else
        {
            Debug.Log("Can't Afford");
            notEnough.active = true;
            timer = timerLength;
            return;
        }

        // Get Projectile
        item = currentProjectile.GetComponent<ShopItem>();

        // Check if it can be bought/is already sold\\
        if (item.buy())
        {
            SaveLoad.data.currentProjectile = item.shopIndex;
        }
        else
        {
            Debug.Log("Can't Afford");
            notEnough.active = true;
            timer = timerLength;
            return;
        }

        // Save
        SaveLoad.Save();

        // Load Menu
        SceneManager.LoadScene("MainMenu");
    }


}
