using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided");
    }

    public void OnTriggerExit(Collider other)
    {
        Debug.Log("Exited");
    }
}
