using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(openShop); // Open Shop on Click
    }

    // Update is called once per frame
    void openShop()
    {
        SceneManager.LoadScene("Shop"); // Load Shop
    }
}
