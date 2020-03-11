using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddObject : MonoBehaviour
{
    public TouchScript ts;
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Cube")
        {
            ts.cubes.Add(other.gameObject);
        }
    }
}
