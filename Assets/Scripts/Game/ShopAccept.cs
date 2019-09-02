using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopAccept : MonoBehaviour
{
    public GameObject currentSpaceship;
    public GameObject currentProjectile;

    private void Awake()
    {
        SaveLoad.Load();

        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(Accept);
    }

    void Accept()
    {
        ShopItem item = currentSpaceship.GetComponent<ShopItem>();

        if (item.buy())
        {
            SaveLoad.data.currentPlayer = item.shopIndex;
        } 
        else
        {
            Debug.Log("Can't Afford");
            return;
        }

        item = currentProjectile.GetComponent<ShopItem>();

        if (item.buy())
        {
            SaveLoad.data.currentProjectile = item.shopIndex;
        }
        else
        {
            Debug.Log("Can't Afford");
            return;
        }

        SaveLoad.Save();
        SceneManager.LoadScene("MainMenu");
    }


}
