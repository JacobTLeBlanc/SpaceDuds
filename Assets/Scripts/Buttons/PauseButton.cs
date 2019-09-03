using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GetComponent<Button>(); // Get Button
        btn.onClick.AddListener(pauseGame); // Pause Game On Click
    }

    void pauseGame()
    {
        GameControl.instance.pause = true; // Pause Game
    }
}
