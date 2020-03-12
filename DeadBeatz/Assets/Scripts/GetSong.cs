using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSong : MonoBehaviour
{
    public AudioSource music = null;
    public AudioClip[] songss;
    void Start()
    {
        string songName = PlayerPrefs.GetString("Song");

        switch (songName)
        {
            case "Mystic Force":
                music.clip = songss[1];
                break;
            case "Myst on the Moor":
                music.clip = songss[2];
                break;
            case "Sandstorm":
                music.clip = songss[0];
                break;
        }
    }
}
