﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySong : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        double startTime = AudioSettings.dspTime + 1;
        Debug.Log(startTime);
    }
}
