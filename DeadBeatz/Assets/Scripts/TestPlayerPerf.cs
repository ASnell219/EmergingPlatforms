using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerPerf : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(PlayerPrefs.GetString("Song"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
