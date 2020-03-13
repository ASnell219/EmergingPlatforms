using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    private void Start()
    {
        //this.transform.Rotate(0, 0, 0);
    }
    void Update()
    {
        this.transform.Translate(0, 0, 8f * Time.deltaTime);
    }
}
