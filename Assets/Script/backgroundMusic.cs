using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundMusic : MonoBehaviour
{

    AudioSource audioSource;

    void Awake()
    {

        // this loops the music between all the scenes
        GameObject[] music = GameObject.FindGameObjectsWithTag("music");



        if (music.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);


    }

    void Update()
    {
        // this retrieves the user's setting if the user should play music or not
        int musicInt = PlayerPrefs.GetInt("Music");

        audioSource = GetComponent<AudioSource>();
        // I have it set that musicInt 1 will make the music play. However, for some reason it's reversed.
        // It works. I dunno how. So I will just leave it be.
        if (musicInt == 0)
        {
            audioSource.Play();
        }


    }
}
