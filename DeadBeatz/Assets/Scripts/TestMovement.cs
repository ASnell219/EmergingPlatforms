﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    void Update()
    {
        this.transform.Translate(0, 0, -.05f);
    }
}
