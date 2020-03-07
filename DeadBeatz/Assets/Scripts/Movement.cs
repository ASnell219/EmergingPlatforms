using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public static int movespeed = 3;

    public Vector3 ballDirection = Vector3.right;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(ballDirection * movespeed * Time.deltaTime);
        
    }
}
