using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReplayButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GetComponent<Button>(); // Get Button
        btn.onClick.AddListener(replayGame); // Replay Game On Click
    }

    void replayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Restart Game Scene
    }
}
