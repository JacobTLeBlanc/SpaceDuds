using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopAccept : MonoBehaviour
{
    public GameObject currentSpaceship; // Current Spaceship
    public GameObject currentProjectile; // Current Projectile

    private void Awake()
    {
        SaveLoad.Load(); // Load

        Button btn = this.GetComponent<Button>(); // Button Component
        btn.onClick.AddListener(Accept); // On Click Accept
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
            return;
        }

        // Save
        SaveLoad.Save();

        // Load Menu
        SceneManager.LoadScene("MainMenu");
    }


}
