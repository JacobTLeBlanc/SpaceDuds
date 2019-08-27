﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GetComponent<Button>(); // Get Button
        btn.onClick.AddListener(openSettings); // On Click Open Settings
    }

    void openSettings()
    {
        SceneManager.LoadScene("Settings"); // Load Settings Scene
    }
}
