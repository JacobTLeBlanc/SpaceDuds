using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    AudioSource audioSource;

    public static Music instance;

    // Start is called before the first frame update
    void Awake()
    {

        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(transform.gameObject); // Don't Destroy between scenes

        audioSource = GetComponent<AudioSource>();
    }

    // Play Music
    public void PlayMusic()
    {
        if (!SaveLoad.data.musicOn)
        {
            return;
        }

        if (audioSource.isPlaying)
        {
            return;
        }

        audioSource.Play();
    }

    // Stop music
    public void StopMusic()
    {
        audioSource.Stop();
    }
    
}
