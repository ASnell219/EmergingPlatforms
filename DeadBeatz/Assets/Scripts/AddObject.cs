using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddObject : MonoBehaviour
{
    public ListManager lm;

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Monster")
        {
            lm.gameObjects.Add(other.gameObject);
        }
    }
}
