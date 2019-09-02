using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public Text highscore;

    // Start is called before the first frame update
    void Start()
    {
        SaveLoad.Load();

        highscore.text = "High: " + SaveLoad.data.highscore.ToString() + " km";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
