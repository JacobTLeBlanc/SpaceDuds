using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnPauseButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(UnPauseGame); // on Click Unpause Game
    }

    void UnPauseGame()
    {
        // Turn on/off UI
        GameControl.instance.healthUI.active = true;
        GameControl.instance.bulletUI.active = true;
        GameControl.instance.pauseMenu.active = false;
        GameControl.instance.controlsUI.active = true;
        GameControl.instance.pause = false;

        // Start scrolling
        GameControl.instance.scrollSpeed = -3.0f + ((1 / GameControl.instance.difficultyScale));
    }

}
