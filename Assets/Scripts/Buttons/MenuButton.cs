using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
   
    void Start()
    {
        Button btn = this.GetComponent<Button>(); // Get Button
        btn.onClick.AddListener(openMenu); // On Click Open Menu
    }

    void openMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Load Menu
    }
}
