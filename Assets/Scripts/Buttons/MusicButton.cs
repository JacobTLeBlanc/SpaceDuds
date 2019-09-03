using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicButton : MonoBehaviour
{
    public Music menuMusic;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(SwitchMusic); // Switch music setting on click
        GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().PlayMusic();

        SaveLoad.Load();
    }

    void SwitchMusic()
    {
        if (SaveLoad.data.musicOn)
        {
            GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().StopMusic();

            SaveLoad.data.musicOn = false;
        }
        else
        {
            SaveLoad.data.musicOn = true;

            GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().PlayMusic();
        }

        SaveLoad.Save();
    }    
}
