using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void Load(string scene)
    {    
        SceneManager.LoadScene(scene);
    }

    public void GetSong(string name)
    {
        PlayerPrefs.SetString("Song", name);
        Load("Scene_Joel");
    }
}
