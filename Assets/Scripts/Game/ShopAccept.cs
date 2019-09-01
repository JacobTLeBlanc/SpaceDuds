using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

        item = currentProjectile.GetComponent<ShopItem>();

        if (item.buy())
        {
            SaveLoad.data.currentProjectile = item.shopIndex;
        }

        SaveLoad.Save();
    }


}
