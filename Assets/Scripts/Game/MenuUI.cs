using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public Text highscore; // Get Text UI

    // Start is called before the first frame update
    void Start()
    {
        SaveLoad.Load(); // Load

        highscore.text = "High: " + SaveLoad.data.highscore.ToString() + " km"; // Set Highscore
    }
}
