﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GetComponent<Button>(); // Get Button
        btn.onClick.AddListener(playGame); // Play Game On Click
    }

    void playGame()
    {
        SceneManager.LoadScene("GameScene"); // Open Game 
    }
}
